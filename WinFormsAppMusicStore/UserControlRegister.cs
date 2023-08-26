using ClassLibraryExcel;
using ClassLibraryModels;
using ClassLibraryServices;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore;
using System.Data;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;
using LiveChartsCore.SkiaSharpView.VisualElements;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlRegister : UserControl
    {
        private IServices _service;
        private List<User> _users;
        private List<Store> _stores;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;

        public UserControlRegister(IServices services, List<User> users, List<Store> stores,
            EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            _service = services;
            _users = users;
            _stores = new List<Store>(stores).Where(x => x.code != "0000").ToList();
            dateTimePickerDate.Value = DateTime.Now;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            LoadComboBoxStores();
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
                var result = await _service.RegisterService.GetRegisterByMonth(((Store)comboBoxStore.SelectedItem).id, dateTimePickerDate.Value.Date);
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
                if (registers[i].activity == 1 &&
                    registers[i + 1].activity == 1 &&
                    datesWeek.ContainsKey(registers[i].creationDateTime.Date))
                {
                    if (registers[i + 1].creationDateTime.Date == registers[i].creationDateTime.Date &&
                        (registers[i + 1].creationDateTime - registers[i].creationDateTime).TotalMinutes >= 25 &&
                        (registers[i + 1].creationDateTime - registers[i].creationDateTime).TotalMinutes <= 35)
                    {
                        datesWeek[registers[i].creationDateTime.Date] += 0.5; //aumento el registro en el diccionario
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
                if (registers[i].activity == 1 &&
                    registers[i + 1].activity == 1 &&
                    datesMonth.ContainsKey(registers[i].creationDateTime.Date))
                {
                    if (registers[i + 1].creationDateTime.Date == registers[i].creationDateTime.Date &&
                        (registers[i + 1].creationDateTime - registers[i].creationDateTime).TotalMinutes >= 25 &&
                        (registers[i + 1].creationDateTime - registers[i].creationDateTime).TotalMinutes <= 35)
                    {
                        datesMonth[registers[i].creationDateTime.Date] += 0.5; //aumento el registro en el diccionario
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
            dataGridViewRegisters.DataSource = registers.Select(x => new RegisterDisplay { storeCode = _stores.Where(u => u.id == x.storeId).Select(u => u.code).FirstOrDefault(), activity = x.activity == 1 ? "Reproduciendo" : "Detenido", message = x.message, creationDateTime = x.creationDateTime }).ToList();
            dataGridViewRegisters.Columns[0].HeaderText = "Tienda";
            dataGridViewRegisters.Columns[1].HeaderText = "Actividad";
            dataGridViewRegisters.Columns[2].HeaderText = "Mensaje";
            dataGridViewRegisters.Columns[3].HeaderText = "Tiempo Creacion";
            dataGridViewRegisters.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridViewRegisters.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
        }

        private async void buttonEraseRegisters_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"¿Está seguro de eliminar todos los registros de la tienda {((Store)comboBoxStore.SelectedItem).code}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = await _service.RegisterService.RegisterDelete(((Store)comboBoxStore.SelectedItem).id);
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
                    var result = await ManageExcel.CreateReportStore((List<RegisterDisplay>)dataGridViewRegisters.DataSource, savePathFile);
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
