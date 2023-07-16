﻿using ClassLibraryModels;
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

namespace WinFormsAppMusicStore
{
    public partial class UserControlUser : UserControl
    {
        private IServices _services;
        private User _user;
        private List<User> _users;
        private List<Store> _stores;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private EventHandler<List<User>> _raiseUpdateUsers;

        public UserControlUser(IServices services, User user, List<User> users,
            List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage,
            EventHandler<List<User>> raiseUpdateUsers)
        {
            InitializeComponent();
            _services = services;
            _user = user;
            _users = users;
            _stores = stores;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _raiseUpdateUsers = raiseUpdateUsers;
            LoadData();
        }

        private void LoadData()
        {
            LoadComboBoxUserEdit();
            comboBoxUserEdit.SelectedIndexChanged -= comboBoxUserEdit_SelectedIndexChanged;
            comboBoxUserEdit.SelectedIndex = -1;
            comboBoxUserEdit.SelectedIndexChanged += comboBoxUserEdit_SelectedIndexChanged;
            textBoxUserEditAlias.Text = string.Empty;
            textBoxUserEditPassword.Text = string.Empty;
            LoadComboBoxUserEditStore();
            comboBoxUserEditStore.SelectedIndex = -1;
            textBoxUserAddAlias.Text = string.Empty;
            textBoxUserAddPassword.Text = string.Empty;
            LoadComboBoxUserAddStore();
            comboBoxUserAddStore.SelectedIndex = -1;
            radioButtonUserEditAdmin.Checked = true;
            radioButtonUserAddAdmin.Checked = true;
        }

        private void LoadComboBoxUserEdit()
        {
            comboBoxUserEdit.DataSource = _users;
            comboBoxUserEdit.DisplayMember = "alias";
            comboBoxUserEdit.ValueMember = "id";
        }

        private void LoadComboBoxUserEditStore()
        {
            comboBoxUserEditStore.DataSource = new List<Store>(_stores).Where(x => x.code != "0000").ToList();
            comboBoxUserEditStore.DisplayMember = "code";
            comboBoxUserEditStore.ValueMember = "id";
        }

        private void LoadComboBoxUserAddStore()
        {
            comboBoxUserAddStore.DataSource = new List<Store>(_stores).Where(x => x.code != "0000").ToList();
            comboBoxUserAddStore.DisplayMember = "code";
            comboBoxUserAddStore.ValueMember = "id";
        }

        private void comboBoxUserEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxUserEdit.SelectedIndex == -1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe seleccionar un usuario."));
                return;
            }

            textBoxUserEditAlias.Text = ((User)comboBoxUserEdit.SelectedItem).alias;
            if (((User)comboBoxUserEdit.SelectedItem).rol == "Admin")
            {
                radioButtonUserEditAdmin.Checked = true;
                radioButtonUserEditStore.Checked = false;
                comboBoxUserEditStore.SelectedIndex = -1;
                comboBoxUserEditStore.Enabled = false;
            }
            else
            {
                radioButtonUserEditAdmin.Checked = false;
                radioButtonUserEditStore.Checked = true;
                comboBoxUserEditStore.SelectedIndex = -1;
                comboBoxUserEditStore.Enabled = true;

                foreach (var item in comboBoxUserEditStore.Items)
                {
                    if (((Store)item).id == ((User)comboBoxUserEdit.SelectedItem).storeId)
                    {
                        comboBoxUserEditStore.SelectedItem = item;
                        break;
                    }
                }
            }
        }

        private void radioButtonUserEditAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUserEditAdmin.Checked)
            {
                comboBoxUserEditStore.SelectedIndex = -1;
                comboBoxUserEditStore.Enabled = false;
            }
        }

        private void radioButtonUserEditStore_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUserEditStore.Checked)
            {
                comboBoxUserEditStore.SelectedIndex = -1;
                comboBoxUserEditStore.Enabled = true;
            }
        }

        private void BlockControls()
        {
            comboBoxUserEdit.Enabled = false;
            textBoxUserEditAlias.Enabled = false;
            textBoxUserEditPassword.Enabled = false;
            radioButtonUserEditAdmin.Enabled = false;
            radioButtonUserEditStore.Enabled = false;
            comboBoxUserEditStore.Enabled = false;
            buttonStoreUserEdit.Enabled = false;
            buttonUserDelete.Enabled = false;
            textBoxUserAddAlias.Enabled = false;
            textBoxUserAddPassword.Enabled = false;
            radioButtonUserAddAdmin.Enabled = false;
            radioButtonUserAddStore.Enabled = false;
            comboBoxUserAddStore.Enabled = false;
            buttonUserAdd.Enabled = false;
            buttonUserRefreshData.Enabled = false;
        }

        private void UnblockControls()
        {
            comboBoxUserEdit.Enabled = true;
            textBoxUserEditAlias.Enabled = true;
            textBoxUserEditPassword.Enabled = true;
            radioButtonUserEditAdmin.Enabled = true;
            radioButtonUserEditStore.Enabled = true;
            comboBoxUserEditStore.Enabled = true;
            buttonStoreUserEdit.Enabled = true;
            buttonUserDelete.Enabled = true;
            textBoxUserAddAlias.Enabled = true;
            textBoxUserAddPassword.Enabled = true;
            radioButtonUserAddAdmin.Enabled = true;
            radioButtonUserAddStore.Enabled = true;
            comboBoxUserAddStore.Enabled = true;
            buttonUserAdd.Enabled = true;
            buttonUserRefreshData.Enabled = true;
        }

        private async void buttonStoreUserEdit_Click(object sender, EventArgs e)
        {
            BlockControls();

            if (comboBoxUserEdit.SelectedIndex == -1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe seleccionar un usuario."));
                UnblockControls();
                return;
            }



            if (ValidateUserEditInput() == false)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Campos de usuario invalidos."));
                UnblockControls();
                return;
            }

            int storeId = 0;
            string rol = string.Empty;
            if (radioButtonUserEditAdmin.Checked)
            {
                storeId = 1;
                rol = "Admin";
            }
            else
            {
                storeId = ((Store)comboBoxUserEditStore.SelectedItem).id;
                rol = "Store";
                if (((User)comboBoxUserEdit.SelectedItem).rol == "Admin")
                {
                    _raiseRichTextInsertMessage?.Invoke(this, (false, "Los usuarios administradores no pueden ser usuario de tienda."));
                    UnblockControls();
                    return;
                }
            }

            var result = await _services.UserService.UserUpdate(
                new User
                {
                    id = ((User)comboBoxUserEdit.SelectedItem).id,
                    alias = textBoxUserEditAlias.Text,
                    password = textBoxUserEditPassword.Text,
                    storeId = storeId,
                    rol = rol,
                    creationDateTime = DateTime.Now
                });

            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));

            if (result.status)
            {
                buttonUserRefreshData_Click(null, null);
            }

            UnblockControls();
        }

        private bool ValidateUserEditInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxUserEditAlias.Text) || string.IsNullOrWhiteSpace(textBoxUserEditPassword.Text))
            {
                return false;
            }

            if (radioButtonUserEditStore.Checked && comboBoxUserEditStore.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        private async void buttonUserDelete_Click(object sender, EventArgs e)
        {
            BlockControls();

            if (comboBoxUserEdit.SelectedIndex == -1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe seleccionar un usuario."));
                UnblockControls();
                return;
            }

            if (((User)comboBoxUserEdit.SelectedItem).id == _user.id)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "No puede eliminar el usuario activo."));
                UnblockControls();
                return;
            }

            var result = await _services.UserService.UserDelete(
                new User
                {
                    id = ((User)comboBoxUserEdit.SelectedItem).id
                });

            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));

            if (result.status)
            {
                buttonUserRefreshData_Click(null, null);
            }

            UnblockControls();
        }

        private async void buttonUserAdd_Click(object sender, EventArgs e)
        {
            BlockControls();

            if (ValidateUserAddInput() == false)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Campos de usuario invalidos."));
                UnblockControls();
                return;
            }

            int storeId = 0;
            string rol = string.Empty;
            if (radioButtonUserAddAdmin.Checked)
            {
                storeId = 1;
                rol = "Admin";
            }
            else
            {
                storeId = ((Store)comboBoxUserAddStore.SelectedItem).id;
                rol = "Store";
            }

            var result = await _services.UserService.UserCrete(
                new User
                {
                    alias = textBoxUserAddAlias.Text,
                    password = textBoxUserAddPassword.Text,
                    storeId = storeId,
                    rol = rol,
                    creationDateTime = DateTime.Now
                });

            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));

            if (result.status)
            {
                buttonUserRefreshData_Click(null, null);
            }

            UnblockControls();
        }

        private bool ValidateUserAddInput()
        {
            if (string.IsNullOrWhiteSpace(textBoxUserAddAlias.Text) || string.IsNullOrWhiteSpace(textBoxUserAddPassword.Text))
            {
                return false;
            }

            if (radioButtonUserAddStore.Checked && comboBoxUserAddStore.SelectedIndex == -1)
            {
                return false;
            }

            return true;
        }

        private async void buttonUserRefreshData_Click(object sender, EventArgs e)
        {
            BlockControls();
            var result = await _services.UserService.UserGetAll();
            if (result.status)
            {
                _users = result.data;
                _raiseUpdateUsers?.Invoke(this, result.data);
                LoadData();
            }

            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));

            UnblockControls();
        }

        private void radioButtonUserAddAdmin_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUserAddAdmin.Checked)
            {
                comboBoxUserAddStore.SelectedIndex = -1;
                comboBoxUserAddStore.Enabled = false;
            }
        }

        private void radioButtonUserAddStore_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonUserAddStore.Checked)
            {
                comboBoxUserAddStore.SelectedIndex = -1;
                comboBoxUserAddStore.Enabled = true;
            }
        }
    }
}
