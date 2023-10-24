using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.Data;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.VisualElements;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;
using System.Windows.Forms;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlRegister : UserControl
    {
        private readonly int _timeInterval;
        private readonly IRegisterDriving _registerDriving;
        private readonly IExcelDriving _excelDriving;
        private List<User> _users;
        private List<Store> _stores;
        private List<Register> _registers;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;

        ToolTip toolTipButtonSearchRegisters = new ToolTip();
        ToolTip toolTipButtonExcel = new ToolTip();
        ToolTip toolTipButtonDeleteRegisters = new ToolTip();

        public UserControlRegister(int timeInterval, IRegisterDriving registerDriving, IExcelDriving excelDriving, List<User> users, List<Store> stores,
            EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            InitToolTips();
            _timeInterval = timeInterval;
            _registerDriving = registerDriving;
            _excelDriving = excelDriving;
            _users = users;
            _stores = new List<Store>(stores).Where(x => x.Code != "0000").ToList();
            dateTimePickerDate.Value = DateTime.Now;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            LoadComboBoxStores();
        }

        private void InitToolTips()
        {
            toolTipButtonSearchRegisters.SetToolTip(buttonSearchRegisters, "Buscar registros.");
            toolTipButtonExcel.SetToolTip(buttonExportToExcel, "Exportar a Excel.");
            toolTipButtonDeleteRegisters.SetToolTip(buttonEraseRegisters, "Eliminar registros");
        }

        private void LoadComboBoxStores()
        {
            comboBoxStore.DataSource = new List<Store>(_stores);
            comboBoxStore.DisplayMember = "code";
            comboBoxStore.ValueMember = "id";
        }

        private async void buttonSearchRegisters_Click(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var result = await _registerDriving.GetByIdAndMonthAsync(((Store)comboBoxStore.SelectedItem).Id, dateTimePickerDate.Value.Date);
                _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));

                if (result.status)
                {
                    CreateChartWeek(result.data);
                    CreateChartMonth(result.data);
                    LoadRegistersGrid(result.data);
                }
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar una tienda."));
            }
        }

        private void CreateChartWeek(List<Register> registers)
        {
            var datesWeek = GetXAxesDateWeek();
            cartesianChartWeek.XAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = datesWeek.Keys.ToArray().Select(x => x.ToString("dd-MM-yyyy")).ToList(),
                }
            };

            for (int i = 0; i < registers.Count() - 1; i++)
            {
                if (registers[i].Activity == 1 &&
                    registers[i + 1].Activity == 1 &&
                    datesWeek.ContainsKey(registers[i].CreationDateTime.Date))
                {
                    if (registers[i + 1].CreationDateTime.Date == registers[i].CreationDateTime.Date &&
                        (registers[i + 1].CreationDateTime - registers[i].CreationDateTime).TotalMinutes >= _timeInterval - 5 &&
                        (registers[i + 1].CreationDateTime - registers[i].CreationDateTime).TotalMinutes <= _timeInterval + 5)
                    {
                        datesWeek[registers[i].CreationDateTime.Date] += _timeInterval * 0.01666666666666666666666666666667; //aumento el registro en el diccionario
                    }
                }
            }

            cartesianChartWeek.Series = new ISeries[]
            {
                    new LineSeries<double>
                    {
                        Values = datesWeek.Values.ToArray(),
                        Fill = null,
                        LineSmoothness = 1,
                        GeometryFill = new SolidColorPaint(SKColors.AliceBlue),
                        Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 2},
                        GeometryStroke = new SolidColorPaint(SKColors.Gray) { StrokeThickness = 4 }
                    }
            };

            cartesianChartWeek.Title =
            new LabelVisual
            {
                Text = "Horas reproducidas semanalmente",
                TextSize = 20,
                Padding = new LiveChartsCore.Drawing.Padding(15),
                Paint = new SolidColorPaint(SKColors.DarkSlateGray)
            };
        }

        private void CreateChartMonth(List<Register> registers)
        {
            var datesMonth = GetXAxesDateMonth();
            cartesianChartMonth.XAxes = new List<Axis>
            {
                new Axis
                {
                    // Use the labels property to define named labels.
                    Labels = datesMonth.Keys.ToArray().Select(x => x.ToString("dd")).ToList(),
                }
            };

            for (int i = 0; i < registers.Count() - 1; i++)
            {
                if (registers[i].Activity == 1 &&
                    registers[i + 1].Activity == 1 &&
                    datesMonth.ContainsKey(registers[i].CreationDateTime.Date))
                {
                    if (registers[i + 1].CreationDateTime.Date == registers[i].CreationDateTime.Date &&
                        (registers[i + 1].CreationDateTime - registers[i].CreationDateTime).TotalMinutes >= _timeInterval - 5 &&
                        (registers[i + 1].CreationDateTime - registers[i].CreationDateTime).TotalMinutes <= _timeInterval + 5)
                    {
                        datesMonth[registers[i].CreationDateTime.Date] += _timeInterval * 0.01666666666666666666666666666667; //aumento el registro en el diccionario
                    }
                }
            }

            cartesianChartMonth.Series = new ISeries[]
            {
                    new LineSeries<double>
                    {
                        Values = datesMonth.Values.ToArray(),
                        Fill = null,
                        LineSmoothness = 1,
                        GeometryFill = new SolidColorPaint(SKColors.AliceBlue),
                        Stroke = new SolidColorPaint(SKColors.Blue) { StrokeThickness = 2},
                        GeometryStroke = new SolidColorPaint(SKColors.Gray) { StrokeThickness = 4 }
                    }
            };

            cartesianChartMonth.Title =
            new LabelVisual
            {
                Text = "Horas reproducidas mensualmente",
                TextSize = 20,
                Padding = new LiveChartsCore.Drawing.Padding(15),
                Paint = new SolidColorPaint(SKColors.DarkSlateGray)
            };
        }

        private Dictionary<DateTime, double> GetXAxesDateWeek()
        {
            DateTime lunesDeLaSemana = dateTimePickerDate.Value.AddDays(-(int)dateTimePickerDate.Value.DayOfWeek);
            lunesDeLaSemana = lunesDeLaSemana.AddDays(1);
            DateTime domingoDeLaSemana = lunesDeLaSemana.AddDays(6);

            var dic = new Dictionary<DateTime, double>();

            for (DateTime diaSemana = lunesDeLaSemana; diaSemana <= domingoDeLaSemana; diaSemana = diaSemana.AddDays(1))
            {
                if (diaSemana.Month == dateTimePickerDate.Value.Month) // Verificar si el día de la semana pertenece al mismo mes
                {
                    dic.Add(diaSemana.Date, 0);
                }
            }

            return dic;
        }

        private Dictionary<DateTime, double> GetXAxesDateMonth()
        {
            DateTime primerDiaMes = new DateTime(dateTimePickerDate.Value.Year, dateTimePickerDate.Value.Month, 1);
            DateTime ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

            var dic = new Dictionary<DateTime, double>();
            for (DateTime diaSemana = primerDiaMes; diaSemana <= ultimoDiaMes; diaSemana = diaSemana.AddDays(1))
            {
                if (diaSemana.Month == dateTimePickerDate.Value.Month) // Verificar si el día de la semana pertenece al mismo mes
                {
                    dic.Add(diaSemana.Date, 0);
                }
            }

            return dic;
        }

        private void LoadRegistersGrid(List<Register> registers)
        {
            _registers = registers;
            dataGridViewRegisters.DataSource = registers.Select(x => new RegisterDisplay { storeCode = _stores.Where(u => u.Id == x.StoreId).Select(u => u.Code).FirstOrDefault(), activity = x.Activity == 1 ? "Reproduciendo" : "Detenido", message = x.Message, creationDateTime = x.CreationDateTime }).ToList();
            dataGridViewRegisters.Columns[0].HeaderText = "Tienda";
            dataGridViewRegisters.Columns[1].HeaderText = "Actividad";
            dataGridViewRegisters.Columns[2].HeaderText = "Mensaje";
            dataGridViewRegisters.Columns[3].HeaderText = "Tiempo Creacion";
            dataGridViewRegisters.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.AutoResizeColumns();
        }

        private async void buttonEraseRegisters_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Está seguro de eliminar todos los registros de la tienda {((Store)comboBoxStore.SelectedItem).Code}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _registerDriving.DeleteAllByStoreIdAsync(((Store)comboBoxStore.SelectedItem).Id);
                _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            }
        }

        private async void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            if (dataGridViewRegisters.DataSource != null && ((List<RegisterDisplay>)dataGridViewRegisters.DataSource).Count > 0)
            {
                string savePathFile = GetSavePathExcel();
                if (savePathFile != string.Empty)
                {
                    var result = await _excelDriving.ExportRegisters(_registers, _stores, savePathFile);
                    _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
                }
                else
                {
                    _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar una ruta de acceso para guardar el archivo."));
                }
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error registros vacios."));
            }
        }

        private string GetSavePathExcel()
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog.Title = "Save XLSX File";
            saveFileDialog.CheckFileExists = false;
            saveFileDialog.CheckPathExists = true;
            saveFileDialog.DefaultExt = "XLSX";
            saveFileDialog.Filter = "XLSX files (*.xlsx)|*.xlsx";
            saveFileDialog.FilterIndex = 2;
            saveFileDialog.RestoreDirectory = true;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                return saveFileDialog.FileName;
            }
            else
            {
                return string.Empty;
            }
        }


    }
}
