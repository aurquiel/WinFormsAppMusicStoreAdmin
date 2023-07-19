using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class FormMain : Form
    {
        private IServices _services;
        private ILogger _logger;
        private IFileManager _fileManager;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private EventHandler<List<Store>> _raiseUpdateStores;
        private EventHandler<List<User>> _raiseUpdateUsers;

        private User _user;
        private List<User> _users;
        private List<Store> _stores;
        private List<UserControl> _userControlList;

        private enum USER_CONTORL_ELEMENTS { INIT = 0, MUSIC = 1, PLAYER = 2, REGISTER = 3, STORE = 4, USER = 5 }

        public FormMain(IServices services, ILogger logger, User user, List<User> users, List<Store> stores)
        {
            InitializeComponent();
            WireUpEvents();
            _services = services;
            _logger = logger;
            _user = user;
            _users = users;
            _stores = stores;
            _fileManager = new FileManager();
            _userControlList = InitUserContorlList();
            OpenChildForm(_userControlList[0]);
            _users = users;
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        private void WireUpEvents()
        {
            this._raiseRichTextInsertMessage += UpdateOnRichTextInsertNewMessage;
            this._raiseUpdateStores += UpdateStore;
            this._raiseUpdateUsers += UpdateUsers;
        }

        private void UpdateOnRichTextInsertNewMessage(object sender, (bool, string) e)
        {
            if (e.Item1)
            {
                _logger.Information(e.Item2);
                AppendText(true, e.Item2, Color.Green, true);
            }
            else
            {
                _logger.Error(e.Item2);
                AppendText(false, e.Item2, Color.Red, true);
            }
        }

        private string GetTime()
        {
            return "Tiempo: " + DateTime.Now.ToString(@"hh\:mm\:ss\:fff") + ". ";
        }

        private void AppendText(bool status, string text, Color color, bool addNewLine = false)
        {
            if (status)
            {
                text = text.Insert(0, "EXITOSO: " + GetTime());
            }
            else
            {
                text = text.Insert(0, "ERROR: " + GetTime());
            }

            richTextBoxStatusMessages.SuspendLayout();
            richTextBoxStatusMessages.SelectionColor = color;
            richTextBoxStatusMessages.AppendText(addNewLine ? $"{text}{Environment.NewLine}" : text);
            richTextBoxStatusMessages.ScrollToCaret();
            richTextBoxStatusMessages.ResumeLayout();
        }

        private void UpdateStore(object? sender, List<Store> e)
        {
            _stores = e;
            _userControlList[(int)USER_CONTORL_ELEMENTS.REGISTER] = new UserControlRegister(_services, _users, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.STORE] = new UserControlStore(_services, _stores, _raiseRichTextInsertMessage, _raiseUpdateStores);
            _userControlList[(int)USER_CONTORL_ELEMENTS.USER] = new UserControlUser(_services, _user, _users, _stores, _raiseRichTextInsertMessage, _raiseUpdateUsers);
        }

        private void UpdateUsers(object? sender, List<User> e)
        {
            _users = e;
            _user = _users.Where(x => x.id == _user.id).FirstOrDefault();
            _userControlList[(int)USER_CONTORL_ELEMENTS.REGISTER] = new UserControlRegister(_services, _users, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.USER] = new UserControlUser(_services, _user, _users, _stores, _raiseRichTextInsertMessage, _raiseUpdateUsers);
        }

        private List<UserControl> InitUserContorlList()
        {
            return new List<UserControl> {
                new UserControlInit(),
                new UserControlMusic(_services, _fileManager, _raiseRichTextInsertMessage),
                new UserControlPlayer(_services, _fileManager, _raiseRichTextInsertMessage),
                new UserControlRegister(_services, _users, _stores, _raiseRichTextInsertMessage),
                new UserControlStore(_services, _stores, _raiseRichTextInsertMessage, _raiseUpdateStores),
                new UserControlUser(_services, _user, _users, _stores, _raiseRichTextInsertMessage, _raiseUpdateUsers)
            };
        }

        private void OpenChildForm(UserControl childForm)
        {
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Clear();
            panelChildForm.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void ButtonReColorMainMenu()
        {
            buttonMusic.BackColor = Color.RoyalBlue;
            buttonPlayer.BackColor = Color.RoyalBlue;
            buttonRegister.BackColor = Color.RoyalBlue;
            buttonStore.BackColor = Color.RoyalBlue;
            buttonUser.BackColor = Color.RoyalBlue;
        }

        private void buttonMusic_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonMusic.BackColor = Color.Blue;
            OpenChildForm(_userControlList[1]);
            richTextBoxStatusMessages.Clear();
        }

        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonPlayer.BackColor = Color.Blue;
            OpenChildForm(_userControlList[2]);
            richTextBoxStatusMessages.Clear();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonRegister.BackColor = Color.Blue;
            OpenChildForm(_userControlList[3]);
            richTextBoxStatusMessages.Clear();
        }

        private void buttonStore_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonStore.BackColor = Color.Blue;
            OpenChildForm(_userControlList[4]);
            richTextBoxStatusMessages.Clear();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonUser.BackColor = Color.Blue;
            OpenChildForm(_userControlList[5]);
            richTextBoxStatusMessages.Clear();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            foreach (var userControl in _userControlList)
            {
                userControl.Dispose();
            }
            _userControlList = new List<UserControl>();
            Close();
        }
    }
}
