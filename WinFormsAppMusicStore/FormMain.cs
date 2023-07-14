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

namespace WinFormsAppMusicStore
{
    public partial class FormMain : Form
    {
        private IServices _service;
        private ILogger _logger;
        private IFileManager _fileManager;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;

        private User _user;
        private List<UserControl> _userControlList;

        public FormMain(IServices services, ILogger logger, User user)
        {
            InitializeComponent();
            WireUpEvents();
            _service = services;
            _logger = logger;
            _user = user;
            _fileManager = new FileManager();
            _userControlList = new List<UserControl> { new UserControlInit(), new UserControlMusic(_service, _raiseRichTextInsertMessage, _fileManager) };
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
            richTextBoxStatusMessages.Clear();
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonRegister.BackColor = Color.Blue;
            richTextBoxStatusMessages.Clear();
        }

        private void buttonUser_Click(object sender, EventArgs e)
        {
            ButtonReColorMainMenu();
            buttonUser.BackColor = Color.Blue;
            richTextBoxStatusMessages.Clear();
        }
    }
}
