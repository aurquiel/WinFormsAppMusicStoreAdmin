using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using System.Data;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlStore : UserControl
    {
        private IStoreDriving _storeDriving;
        private List<Store> _stores;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private EventHandler<List<Store>> _raiseUpdateStores;

        private ToolTip _editStore = new ToolTip();
        private ToolTip _addStore = new ToolTip();
        private ToolTip _deleteStore = new ToolTip();
        private ToolTip _refreshStore = new ToolTip();

        public UserControlStore(IStoreDriving storeDriving, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage,
            EventHandler<List<Store>> raiseUpdateStores)
        {
            InitializeComponent();
            InitTooltip();
            _storeDriving = storeDriving;
            _stores = stores;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _raiseUpdateStores = raiseUpdateStores;
            LoadComboBoxStores();
            comboBoxStoreEdit.SelectedIndex = -1;
            textBoxStoreEditCode.Text = string.Empty;
        }

        private void InitTooltip()
        {
            _editStore.SetToolTip(buttonStoreEdit, "Editar tienda.");
            _addStore.SetToolTip(buttonStoreAdd, "Crear tienda.");
            _deleteStore.SetToolTip(buttonStoreDelete, "Eliminar tienda.");
            _refreshStore.SetToolTip(buttonStoreRefreshData, "Refrescar tiendas.");
        }

        private void LoadComboBoxStores()
        {
            comboBoxStoreEdit.DataSource = _stores.Where(x => x.Code != "0000").ToList();
            comboBoxStoreEdit.DisplayMember = "code";
            comboBoxStoreEdit.ValueMember = "id";
        }

        private void BlockControls()
        {
            comboBoxStoreEdit.Enabled = false;
            textBoxStoreEditCode.Enabled = false;
            buttonStoreEdit.Enabled = false;
            buttonStoreDelete.Enabled = false;
            textBoxStoreAddCode.Enabled = false;
            buttonStoreAdd.Enabled = false;
            buttonStoreRefreshData.Enabled = false;
        }

        private void UnblockControls()
        {
            comboBoxStoreEdit.Enabled = true;
            textBoxStoreEditCode.Enabled = true;
            buttonStoreEdit.Enabled = true;
            buttonStoreDelete.Enabled = true;
            textBoxStoreAddCode.Enabled = true;
            buttonStoreAdd.Enabled = true;
            buttonStoreRefreshData.Enabled = true;
        }

        private void comboBoxStoreEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStoreEdit.SelectedIndex != -1)
            {
                textBoxStoreEditCode.Text = ((Store)comboBoxStoreEdit.SelectedItem).Code;
            }
        }

        private async void buttonStoreEdit_Click(object sender, EventArgs e)
        {
            BlockControls();
            if (comboBoxStoreEdit.SelectedIndex == -1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe seleccionar una tienda."));
                UnblockControls();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxStoreEditCode.Text))
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe ingresar un codigo de tienda."));
                UnblockControls();
                return;
            }

            var result = await _storeDriving.UpdateAsync(new Store { Id = ((Store)comboBoxStoreEdit.SelectedItem).Id, Code = textBoxStoreEditCode.Text, CreationDateTime = DateTime.Now });
            if (result.status)
            {
                buttonStoreRefreshData_Click(null, null);
                comboBoxStoreEdit.SelectedIndex = -1;
                textBoxStoreEditCode.Text = string.Empty;
            }
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            UnblockControls();
        }

        private async void buttonStoreDelete_Click(object sender, EventArgs e)
        {
            BlockControls();
            if (comboBoxStoreEdit.SelectedIndex == -1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe seleccionar una tienda."));
                UnblockControls();
                return;
            }

            var result = await _storeDriving.DeleteAsync(((Store)comboBoxStoreEdit.SelectedItem).Id, ((Store)comboBoxStoreEdit.SelectedItem).Code);
            if (result.status)
            {
                buttonStoreRefreshData_Click(null, null);
                comboBoxStoreEdit.SelectedIndex = -1;
                textBoxStoreEditCode.Text = string.Empty;
            }
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            UnblockControls();
        }

        private async void buttonStoreAdd_Click(object sender, EventArgs e)
        {
            BlockControls();
            if (string.IsNullOrWhiteSpace(textBoxStoreAddCode.Text))
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe ingresar un codigo de tienda."));
                UnblockControls();
                return;
            }

            var result = await _storeDriving.InsertAsync(new Store { Code = textBoxStoreAddCode.Text, CreationDateTime = DateTime.Now });
            if (result.status)
            {
                buttonStoreRefreshData_Click(null, null);
                comboBoxStoreEdit.SelectedIndex = -1;
                textBoxStoreEditCode.Text = string.Empty;
                textBoxStoreAddCode.Text = string.Empty;
            }
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            UnblockControls();
        }

        private async void buttonStoreRefreshData_Click(object sender, EventArgs e)
        {
            BlockControls();
            var result = await _storeDriving.GetAllAsync();
            if (result.status)
            {
                _stores = result.data;
                _raiseUpdateStores?.Invoke(this, _stores);
                LoadComboBoxStores();
                comboBoxStoreEdit.SelectedIndex = -1;
                textBoxStoreEditCode.Text = string.Empty;
                textBoxStoreAddCode.Text = string.Empty;
            }
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            UnblockControls();
        }

        private void textBoxOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


    }
}
