using ClassLibraryModels;
using ClassLibraryServices;
using ClassLibraryServices.WebService;
using Serilog;
using System.Configuration;

namespace WinFormsAppMusicStore
{
    public partial class FormLogin : Form
    {
        private WebService _webService;
        private ILogger _logger;

        public FormLogin(ILogger logger)
        {
            InitializeComponent();
            _logger = logger;
            _webService = new WebService(GetIpWebService(), GetTimeoutWebService());
        }

        private string GetIpWebService()
        {
            try
            {
                return ConfigurationManager.AppSettings["IP_WEB_SERVICE"].ToString();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtner ip del webserice del archivo de configuracion", null);
                return "https://192.168.0.203:9097/";
            }
        }

        private int GetTimeoutWebService()
        {
            try
            {
                return Int32.Parse(ConfigurationManager.AppSettings["TIMEOUT_WEB_SERVICE"].ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtner timeout del webserice del archivo de configuracion", null);
                return 600; //10 min para descargar una cancion
            }
        }

        private void UpdateUiFromLoadStore((bool, string) result)
        {
            if (result.Item1)
            {
                TextBoxStatusUpdate(result.Item2, Color.Green);
            }
            else
            {
                TextBoxStatusUpdate(result.Item2, Color.Red);
            }
        }

        private void TextBoxStatusUpdate(string text, Color colorBrush)
        {
            this.textBoxStatus.Text = text;
            this.textBoxStatus.ForeColor = colorBrush;
            this.textBoxStatus.BackColor = this.textBoxStatus.BackColor;
        }

        private (bool, string) ValidateInputUser()
        {
            if (string.IsNullOrWhiteSpace(textBoxUserAlias.Text))
            {
                return new(false, "Error campo de usuario vacio.");
            }
            else if (string.IsNullOrWhiteSpace(textBoxUserPassword.Text))
            {
                return new(false, "Error campo de contraseņa de usuario vacio.");
            }
            else
            {
                return new(true, "Entrada de datos de usuarios validados.");
            }
        }

        private async void buttonLogin_Click(object sender, EventArgs e)
        {
            DisableControl();

            var resultValidateUser = ValidateInputUser();

            if (resultValidateUser.Item1 == false)
            {
                UpdateUiFromLoadStore(resultValidateUser);
                goto ERROR_LOGGIN;
            }

            UpdateUiFromLoadStore((true, "Obteniendo data del servidor..."));
            await Task.Delay(300);

            var resultUserAccess = await _webService.UserService.UserAccess(new UserAccess { alias = textBoxUserAlias.Text, password = textBoxUserPassword.Text });

            if (resultUserAccess.status == false)
            {
                UpdateUiFromLoadStore((resultUserAccess.status, resultUserAccess.statusMessage));
                goto ERROR_LOGGIN;
            }

            _webService.SetToken(resultUserAccess.data.token);

            LaunchMainWindows(resultUserAccess.data.user);
            UpdateUiFromLoadStore((true, string.Empty));
            ClearTextFileds();

        ERROR_LOGGIN:
            EnableControl();
        }

        private void DisableControl()
        {
            buttonLogin.Enabled = false;
            textBoxUserAlias.Enabled = false;
            textBoxUserPassword.Enabled = false;
        }

        private void EnableControl()
        {
            buttonLogin.Enabled = true;
            textBoxUserAlias.Enabled = true;
            textBoxUserPassword.Enabled = true;
        }

        private void ClearTextFileds()
        {
            textBoxUserAlias.Text = String.Empty;
            textBoxUserPassword.Text = String.Empty;
        }

        private void LaunchMainWindows(User user)
        {
            this.Hide();
            FormMain formMain = new FormMain(_webService, _logger, user);
            formMain.Closed += (s, args) => this.Show();
            formMain.ShowDialog();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}