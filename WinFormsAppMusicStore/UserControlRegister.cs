using ClassLibraryExcel;
using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            dateTimePickerStoreNoRegister.Value = DateTime.Now;
            dateTimePickerRegisterInit.Value = DateTime.Now;
            dateTimePickerRegisterFinal.Value = DateTime.Now;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            LoadComboBoxStores();
        }

        private void LoadComboBoxStores()
        {
            comboBoxRegisterStore.DataSource = new List<Store>(_stores);
            comboBoxRegisterStore.DisplayMember = "code";
            comboBoxRegisterStore.ValueMember = "id";

            comboBoxRegisterDelete.DataSource = new List<Store>(_stores);
            comboBoxRegisterDelete.DisplayMember = "code";
            comboBoxRegisterDelete.ValueMember = "id";
        }

        private async void buttonRegisterNoStoreSearch_Click(object sender, EventArgs e)
        {
            var result = await _service.RegisterService.GetRegisterByDate(dateTimePickerStoreNoRegister.Value.Date);
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            if (result.status)
            {
                List<Store> storesCode = new List<Store>();
                foreach (var item in result.data)
                {
                    storesCode.Add(new Store { id = item.storeId });
                }

                List<string> storesExcept = new List<string>();
                foreach (var store in _stores)
                {
                    bool flag = false;
                    foreach (var storeC in storesCode)
                    {
                        if (storeC.id == store.id)
                        {
                            flag = true;
                            break;
                        }
                    }

                    if (flag == false)
                    {
                        storesExcept.Add(store.code);
                    }
                }

                listBoxStoreNoRegister.DataSource = storesExcept;
            }
        }

        private bool ValidateInput()
        {
            if (dateTimePickerRegisterInit.Value.Date > dateTimePickerRegisterFinal.Value.Date)
            {
                return false;
            }

            return true;
        }

        private async void buttonRegisterSearch_Click(object sender, EventArgs e)
        {
            if (ValidateInput() == false)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error la fecha inicial no puede ser menor a la fecha final."));
                return;
            }

            var result = await _service.RegisterService.GetRegisters(((Store)comboBoxRegisterStore.SelectedItem).id, dateTimePickerRegisterInit.Value.Date, dateTimePickerRegisterFinal.Value.Date);
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));

            if (result.status)
            {
                dataGridViewRegister.DataSource = result.data.Select(x => new RegisterDisplay { storeCode = _stores.Where(u => u.id == x.storeId).Select(u => u.code).FirstOrDefault(), operation = x.operation, creationDateTime = x.creationDateTime }).ToList();
                dataGridViewRegister.Columns[0].HeaderText = "Tienda";
                dataGridViewRegister.Columns[1].HeaderText = "Operacion";
                dataGridViewRegister.Columns[2].HeaderText = "Tiempo Creacion";
                dataGridViewRegister.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewRegister.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dataGridViewRegister.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            }
        }

        private async void buttonRegisterDelete_Click(object sender, EventArgs e)
        {
            var result = await _service.RegisterService.RegisterDelete(((Store)comboBoxRegisterDelete.SelectedItem).id);
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
        }

        private async void buttonExportToExcel_Click(object sender, EventArgs e)
        {
            if(dataGridViewRegister.DataSource != null && ((List<RegisterDisplay>)dataGridViewRegister.DataSource).Count > 0)
            {
                string savePathFile = GetSavePathExcel();
                if (savePathFile != string.Empty)
                {
                    var result = await ManageExcel.CreateReportStore((List<RegisterDisplay>)dataGridViewRegister.DataSource, savePathFile);
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
            SaveFileDialog saveFileDialog = new SaveFileDialog();
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
