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

namespace WinFormsAppMusicStore
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
            _stores = stores;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
        }
    }
}
