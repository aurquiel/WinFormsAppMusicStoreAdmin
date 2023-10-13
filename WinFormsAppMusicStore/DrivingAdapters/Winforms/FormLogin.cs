using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using Serilog;
using System.Configuration;
using WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms
{
    public partial class FormLogin : Form
    {
        private readonly FormMain _formMain;
        private ILogger _logger;
        private readonly IFileManagerDriving _fileManagerDriving;
        private readonly IUserAccessDriving _userAccessDriving;
        private readonly IUserDriving _userDriving;
        private readonly IStoreDriving _storeDriving;

        public FormLogin(FormMain formMain, ILogger logger, IFileManagerDriving fileManagerDriving, 
            IUserAccessDriving userAccessDriving, IUserDriving userDriving, IStoreDriving storeDriving)
        {
            InitializeComponent();
            _formMain = formMain;
            _logger = logger;
            _fileManagerDriving = fileManagerDriving;
            _fileManagerDriving.CopyLocalDbIfNotExist();
            _userAccessDriving = userAccessDriving;
            _userDriving = userDriving;
            _storeDriving = storeDriving;
            GetIpWebService();
            GetTimeoutWebService();
            GetTimeoutWebServiceHeavyTask();
        }

        private void GetIpWebService()
        {
            try
            {
                WebServiceParams.IP_WEB_SERVICE = ConfigurationManager.AppSettings["IP_WEB_SERVICE"].ToString();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener ip del webservice del archivo de configuracion", null);
                WebServiceParams.IP_WEB_SERVICE = "https://192.168.0.203:9097/";
            }
        }

        private void GetTimeoutWebService()
        {
            try
            {
                WebServiceParams.TIMEOUT_WEB_SERVICE = Int32.Parse(ConfigurationManager.AppSettings["TIMEOUT_WEB_SERVICE"].ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener timeout del webservice del archivo de configuracion", null);
                WebServiceParams.TIMEOUT_WEB_SERVICE = 25;
            }
        }

        private void GetTimeoutWebServiceHeavyTask()
        {
            try
            {
                WebServiceParams.TIMEOUT_WEB_SERVICE_HEAVY_TASK = Int32.Parse(ConfigurationManager.AppSettings["TIMEOUT_WEB_SERVICE_HEAVY_TASK"].ToString());
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener timeout del webservice del archivo de configuracion", null);
                WebServiceParams.TIMEOUT_WEB_SERVICE_HEAVY_TASK = 600; //10 min para descargar o subir una cancion
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
                return new(false, "Error campo de contraseña de usuario vacio.");
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

            var resultUserAccess = await _userAccessDriving.AcccesLoginTokenAsync(textBoxUserAlias.Text, textBoxUserPassword.Text);

            if (resultUserAccess.status == false)
            {
                UpdateUiFromLoadStore((resultUserAccess.status, resultUserAccess.statusMessage));
                _logger.Error("UserAccess: " + resultUserAccess.statusMessage);
                goto ERROR_LOGGIN;
            }

            WebServiceParams.TOKEN_WEB_SERVICE = resultUserAccess.data.token;

            var resultUserGetAll = await _userDriving.GetAllAsync();

            if (resultUserGetAll.status == false)
            {
                UpdateUiFromLoadStore((resultUserGetAll.status, resultUserGetAll.statusMessage));
                _logger.Error("UserGetAll: " + resultUserAccess.statusMessage);
                goto ERROR_LOGGIN;
            }

            var resultStoreGetAll = await _storeDriving.GetAllAsync();

            if (resultStoreGetAll.status == false)
            {
                UpdateUiFromLoadStore((resultStoreGetAll.status, resultStoreGetAll.statusMessage));
                _logger.Error("StoreGetAll: " + resultUserAccess.statusMessage);
                goto ERROR_LOGGIN;
            }

            CreateFolders(resultStoreGetAll.data);

            LaunchMainWindows(resultUserAccess.data.user, resultUserGetAll.data, resultStoreGetAll.data);
            Close();

        ERROR_LOGGIN:
            EnableControl();
        }

        private void CreateFolders(List<Store> stores)
        {
            _fileManagerDriving.CreateDictoriesAndFiles(stores.Where(x => x.Code != "0000").ToList());
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

        private void LaunchMainWindows(User activeUser, List<User> users, List<Store> stores)
        {
            this.Hide();
            _formMain.SetActiveUser(activeUser);
            _formMain.SetUsers(users);
            _formMain.SetStores(stores);
            _formMain.InitUserControls();
            _formMain.ShowDialog();
            _formMain.Close();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}