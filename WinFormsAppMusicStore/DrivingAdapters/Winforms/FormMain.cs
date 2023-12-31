﻿using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Serilog;
using System.Data;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class FormMain : Form
    {
        private ILogger _logger;
        private readonly IMapper _mapper;
        private IAudioDriving _audioDriving;
        private IAudioListDriving _audioListDriving;
        private readonly IUserDriving _userDriving;
        private readonly IFileManagerDriving _fileManagerDriving;
        private readonly IStoreDriving _storeDriving;
        private readonly IRegisterDriving _registerDriving;
        private readonly IExcelDriving _excelDriving;
        private readonly IPlayerDriving _playerDriving;
        private readonly IAudioListLocalDriving _audioListLocalDriving;
        private FormOperationAndWait _formOperationAndWait;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private EventHandler<List<Store>> _raiseUpdateStores;
        private EventHandler<List<User>> _raiseUpdateUsers;

        public User _user;
        public List<User> _users;
        public List<Store> _stores;
        private List<UserControl> _userControlList;
        private int REGISTERS_TIME_INTERVAL_MINUTES;

        private enum USER_CONTORL_ELEMENTS { INIT = 0, MUSIC = 1, TOOLS = 2, PLAYER = 3, REGISTER = 4, STORE = 5, USER = 6 }

        public FormMain(ILogger logger, IMapper mapper, IAudioDriving audioDriving, IAudioListDriving audioListDriving, IUserDriving userDriving,
            IFileManagerDriving fileManagerDriving, IStoreDriving storeDriving, IRegisterDriving registerDriving, IExcelDriving excelDriving,
            IPlayerDriving playerDriving, IAudioListLocalDriving audioListLocalDriving, FormOperationAndWait formOperationAndWait)
        {
            InitializeComponent();
            WireUpEvents();

            _audioDriving = audioDriving;
            _audioListDriving = audioListDriving;
            _userDriving = userDriving;
            _fileManagerDriving = fileManagerDriving;
            _storeDriving = storeDriving;
            _registerDriving = registerDriving;
            _excelDriving = excelDriving;
            _playerDriving = playerDriving;
            _audioListLocalDriving = audioListLocalDriving;
            _formOperationAndWait = formOperationAndWait;
            _logger = logger;
            _mapper = mapper;
        }

        internal void SetRegistersTimeInterval(int time)
        {
            REGISTERS_TIME_INTERVAL_MINUTES = time;
        }

        internal void SetActiveUser(User user)
        {
            _user = user;
        }

        internal void SetUsers(List<User> users)
        {
            _users = users;
        }

        internal void SetStores(List<Store> stores)
        {
            _stores = stores;
        }

        internal void InitUserControls()
        {
            _userControlList = InitUserContorlList();
            OpenChildForm(_userControlList[0]);
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
            _userControlList[(int)USER_CONTORL_ELEMENTS.MUSIC] = new UserControlMusic(_formOperationAndWait, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.TOOLS] = new UserControlTool(_formOperationAndWait, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.PLAYER] = new UserControlPlayer(_formOperationAndWait, _mapper, _playerDriving, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.REGISTER] = new UserControlRegister(REGISTERS_TIME_INTERVAL_MINUTES, _registerDriving, _excelDriving, _users, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.STORE] = new UserControlStore(_storeDriving, _stores, _raiseRichTextInsertMessage, _raiseUpdateStores);
            _userControlList[(int)USER_CONTORL_ELEMENTS.USER] = new UserControlUser(_userDriving, _user, _users, _stores, _raiseRichTextInsertMessage, _raiseUpdateUsers);
        }

        private void UpdateUsers(object? sender, List<User> e)
        {
            _users = e;
            _user = _users.Where(x => x.id == _user.id).FirstOrDefault();
            _userControlList[(int)USER_CONTORL_ELEMENTS.REGISTER] = new UserControlRegister(REGISTERS_TIME_INTERVAL_MINUTES, _registerDriving, _excelDriving, _users, _stores, _raiseRichTextInsertMessage);
            _userControlList[(int)USER_CONTORL_ELEMENTS.USER] = new UserControlUser(_userDriving, _user, _users, _stores, _raiseRichTextInsertMessage, _raiseUpdateUsers);
        }

        private List<UserControl> InitUserContorlList()
        {
            return new List<UserControl> {
                new UserControlInit(),
                new UserControlMusic(_formOperationAndWait, _stores, _raiseRichTextInsertMessage),
                new UserControlTool(_formOperationAndWait, _stores, _raiseRichTextInsertMessage),
                new UserControlPlayer(_formOperationAndWait, _mapper, _playerDriving, _stores, _raiseRichTextInsertMessage),
                new UserControlRegister(REGISTERS_TIME_INTERVAL_MINUTES, _registerDriving, _excelDriving, _users, _stores, _raiseRichTextInsertMessage),
                new UserControlStore(_storeDriving, _stores, _raiseRichTextInsertMessage, _raiseUpdateStores),
                new UserControlUser(_userDriving, _user, _users, _stores, _raiseRichTextInsertMessage, _raiseUpdateUsers)
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

        private void musicaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.MUSIC]);
            richTextBoxStatusMessages.Clear();
        }

        private void reproductorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.PLAYER]);
            richTextBoxStatusMessages.Clear();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.USER]);
            richTextBoxStatusMessages.Clear();
        }

        private void tiendasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.STORE]);
            richTextBoxStatusMessages.Clear();
        }

        private void registrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.REGISTER]);
            richTextBoxStatusMessages.Clear();
        }

        private void herramientasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.TOOLS]);
            richTextBoxStatusMessages.Clear();
        }

        private void buttonPlayer_Click(object sender, EventArgs e)
        {
            OpenChildForm(_userControlList[(int)USER_CONTORL_ELEMENTS.PLAYER]);
            richTextBoxStatusMessages.Clear();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (var userControl in _userControlList)
            {
                userControl.Dispose();
            }
            _userControlList = new List<UserControl>();
        }
    }
}
