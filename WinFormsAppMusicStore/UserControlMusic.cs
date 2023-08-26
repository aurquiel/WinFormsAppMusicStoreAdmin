using ChainOfResponsibilityClassLibrary;
using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using System.ComponentModel;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlMusic : UserControl
    {
        private IServices _services;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private IFileManager _fileManager;
        private List<Store> _stores;
        private BindingSource _bindingAudioListServer = new BindingSource();
        private BindingSource _bindingAudioListStore = new BindingSource();
        private BindingList<AudioFileDTO> _audioListServer = new BindingList<AudioFileDTO>();
        private bool _audioListServerDownloaded = false;
        private BindingList<AudioFileDTO> _audioListStore = new BindingList<AudioFileDTO>();
        private bool _audioListStoreDownloaded = false;
        private BindingList<AudioFileDTO> _audioListStoreChange = new BindingList<AudioFileDTO>();

        private enum OPERATION_UPDATE { NONE = 0, SERVER = 1, STORE = 2 }

        //Tooltips
        ToolTip toolTipButtonPullFromServer = new ToolTip();
        ToolTip toolTipButtonRemoveAudioFromServer = new ToolTip();
        ToolTip toolTipButtonUnselectAll = new ToolTip();
        ToolTip toolTipButtonSelectAll = new ToolTip();
        ToolTip toolTipButtonAddAudiosToServer = new ToolTip();
        ToolTip toolTipButtonSynchronizeAllStores = new ToolTip();
        ToolTip toolTipButtonAddAudioToAudioListStore = new ToolTip();
        ToolTip toolTipButtonRefreshListStore = new ToolTip();
        ToolTip toolTipButtonUnselectAllStoreAudiList = new ToolTip();
        ToolTip toolTipButtonSelectAllStoreAudiList = new ToolTip();
        ToolTip toolTipButtonMoveDown = new ToolTip();
        ToolTip toolTipButtonMoveUp = new ToolTip();
        ToolTip toolTipButtonDeleteAudioAudioListStore = new ToolTip();
        ToolTip toolTipButtonDeleteAllAudioAudioListStore = new ToolTip();
        ToolTip toolTipButtonPushToServer = new ToolTip();

        public UserControlMusic(IServices services, IFileManager fileManager, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            _services = services;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _fileManager = fileManager;
            _stores = stores;
            CreateToolTips();
            LoadComboBoxStores();
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

        private void CreateToolTips()
        {
            toolTipButtonPullFromServer.SetToolTip(buttonPullAudioListFromServer, "Descargar lista de audio del servidor.");
            toolTipButtonRemoveAudioFromServer.SetToolTip(buttonRemoveAudioFromServer, "Remover audio del servidor.");
            toolTipButtonUnselectAll.SetToolTip(buttonUnselectAll, "Deseleccionar todos.");
            toolTipButtonSelectAll.SetToolTip(buttonSelectAll, "Seleccionar todos.");
            toolTipButtonAddAudiosToServer.SetToolTip(buttonAddAudiosToServer, "Agregar audios.");
            toolTipButtonSynchronizeAllStores.SetToolTip(buttonSynchronizeAllStores, "Sincronizar lista de audio de las tiendas.");
            toolTipButtonAddAudioToAudioListStore.SetToolTip(buttonAddAudioToAudioListStore, "Agregar Audios a Lista de Audio Tienda.");
            toolTipButtonRefreshListStore.SetToolTip(buttonRefreshListStore, "Actualizar a Lista de Audio Tienda.");
            toolTipButtonUnselectAllStoreAudiList.SetToolTip(buttonSelectAllAudioListStore, "Deseleccionar todos.");
            toolTipButtonSelectAllStoreAudiList.SetToolTip(buttonSelectAllAudioListStore, "Seleccionar todos.");
            toolTipButtonMoveDown.SetToolTip(buttonMoveDownAudioListStore, "Desplazar abajo.");
            toolTipButtonMoveUp.SetToolTip(buttonMoveUpAudioListStore, "Desplazar arriba.");
            toolTipButtonDeleteAudioAudioListStore.SetToolTip(buttonDeleteAudioAudioListStore, "Eliminar Audio.");
            toolTipButtonDeleteAllAudioAudioListStore.SetToolTip(buttonDeleteAllAudioAudioListStore, "Elimnar todos los audios.");
            toolTipButtonPushToServer.SetToolTip(buttonUploadAudioListStore, "Guardar cambios en el servidor.");
        }

        private void LoadComboBoxStores()
        {
            comboBoxStore.SelectedIndexChanged -= comboBoxStore_SelectedIndexChanged;
            comboBoxStore.DataSource = _stores.Where(x => x.code != "0000").ToList();
            comboBoxStore.DisplayMember = "code";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.SelectedIndex = -1;
            comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
        }

        private void LaunchOperationWaitForm(List<Operation> operations, OPERATION_UPDATE update)
        {
            FormOperationAndWait formWait = new FormOperationAndWait(
                _services,
                _fileManager,
                operations,
                _raiseRichTextInsertMessage);
            formWait.ShowDialog();

            if (update == OPERATION_UPDATE.SERVER)
            {
                if (formWait.AudioFileListDownloaded != null)
                {
                    _audioListServerDownloaded = true;
                    BindListboxServer(formWait.AudioFileListDownloaded);
                }
                else
                {
                    _audioListServerDownloaded = false;
                }
                UpdateServerStadistics();
            }
            else if (update == OPERATION_UPDATE.STORE)
            {
                if (formWait.AudioFileListDownloaded != null)
                {
                    _audioListStoreDownloaded = true;
                    BindListboxStore(formWait.AudioFileListDownloaded);
                }
                else
                {
                    _audioListStoreDownloaded = false;
                    _audioListStore.Clear();
                    comboBoxStore.SelectedIndexChanged -= comboBoxStore_SelectedIndexChanged;
                    comboBoxStore.SelectedIndex = -1;
                    comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
                }
                UpdateStoreStadistics();
            }
        }

        private void BindListboxServer(List<AudioFileDTO> audioFileList)
        {
            _audioListServer = new BindingList<AudioFileDTO>(audioFileList);
            _bindingAudioListServer.DataSource = _audioListServer;
            dataGridViewServer.DataSource = _bindingAudioListServer;
            dataGridViewServer.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewServer.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewServer.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewServer.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonPullAudioFromServer_Click(object sender, EventArgs e)
        {
            var operation = new List<Operation> { new Operation(OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST, string.Empty, new List<AudioFileDTO>()) };
            LaunchOperationWaitForm(operation, OPERATION_UPDATE.SERVER);
            UpdateServerStadistics();
        }

        private void UpdateServerStadistics()
        {
            TimeSpan acumulateTime = new TimeSpan();
            double totalSize = 0;
            foreach (var item in _audioListServer)
            {
                totalSize += Double.Parse(item.size);
                acumulateTime = acumulateTime.Add(item.duration);
            }
            labeServerStadistics.Text = $"Lista Servidor: Audios: {_audioListServer.Count}  Peso Mb: {totalSize.ToString("0.##")} Tiempo: {acumulateTime}";
        }

        private void UpdateStoreStadistics()
        {
            TimeSpan acumulateTime = new TimeSpan();
            double totalSize = 0;
            foreach (var item in _audioListStore)
            {
                totalSize += Double.Parse(item.size);
                acumulateTime = acumulateTime.Add(item.duration);
            }
            labelStoreStadictics.Text = $"Lista Tienda: {((Store)comboBoxStore.SelectedItem).code} Audios: {_audioListStore.Count}  Peso Mb: {totalSize.ToString("0.##")} Tiempo: {acumulateTime}";
        }

        private void buttonRemoveAudioFromServer_Click(object sender, EventArgs e)
        {
            if (_audioListServerDownloaded)
            {
                List<AudioFileDTO> audioFilesToDelete = new List<AudioFileDTO>();
                foreach (var audioFile in _audioListServer)
                {
                    if (audioFile.select)
                    {
                        audioFilesToDelete.Add(audioFile);
                    }
                }

                if (audioFilesToDelete.Count > 0)
                {
                    List<Operation> op = new List<Operation>(){
                        new Operation(OperationTypes.OPERATIONS.SERVER_DELETE_AUDIO, string.Empty, audioFilesToDelete),
                        new Operation(OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST, string.Empty, new List<AudioFileDTO>())
                    };
                    LaunchOperationWaitForm(op, OPERATION_UPDATE.SERVER);
                    comboBoxStore_SelectedIndexChanged(this, null);
                }
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe descargar una lista de audio del servidor."));
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListServer.Count; val++)
            {
                _audioListServer[val].select = false;
            }
            dataGridViewServer.Refresh();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListServer.Count; val++)
            {
                _audioListServer[val].select = true;
            }
            dataGridViewServer.Refresh();
        }

        private void buttonAddAudiosToServer_Click(object sender, EventArgs e)
        {
            if (_audioListServerDownloaded)
            {
                var filesPath = GetFilePathFromDialog();
                var audioFilesToUpload = new List<AudioFileDTO>();
                if (filesPath.Count() > 0)
                {
                    foreach (var file in filesPath)
                    {
                        if (_audioListServer.Any(x => x.name == Path.GetFileName(file)))
                        {
                            _raiseRichTextInsertMessage?.Invoke(this, (false, "Archivo de audio ya existente en la lista. Audio: " + Path.GetFileName(file)));
                        }
                        else
                        {
                            audioFilesToUpload.Add(new AudioFileDTO { name = Path.GetFileName(file), path = file });
                        }
                    }
                }

                if (audioFilesToUpload.Count() > 0)
                {
                    List<Operation> op = new List<Operation>(){
                        new Operation(OperationTypes.OPERATIONS.SERVER_UPLOAD_AUDIO, string.Empty, audioFilesToUpload),
                        new Operation(OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST, string.Empty, new List<AudioFileDTO>())
                    };
                    LaunchOperationWaitForm(op, OPERATION_UPDATE.SERVER);
                }
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe descargar una lista de audio del servidor."));
            }
        }

        private List<string> GetFilePathFromDialog()
        {
            List<string> files = new List<string>();
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.InitialDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                openFileDialog.Filter = "mp3 files (*.mp3)|*.mp3";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in openFileDialog.FileNames)
                    {
                        files.Add(file);
                    }
                    return files;
                }
            }

            return files;
        }

        private void buttonSynchronizeAllStores_Click(object sender, EventArgs e)
        {
            var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.SERVER_SYNCHRONIZE_STORES, string.Empty, new List<AudioFileDTO>()) };
            LaunchOperationWaitForm(op, OPERATION_UPDATE.NONE);
        }

        private void buttonAddAudioToAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStoreDownloaded)
            {
                foreach (var audioserver in _audioListServer)
                {
                    if (audioserver.select)
                    {
                        _audioListStore.Add(
                            new AudioFileDTO
                            {
                                select = false,
                                name = audioserver.name,
                                path = audioserver.path,
                                duration = audioserver.duration,
                                size = audioserver.size
                            });
                    }
                }
                dataGridViewStore.Refresh();
                UpdateStoreStadistics();
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe descargar una lista de audio de tienda."));
            }
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>()) };
                LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
            }
        }

        private void BindListboxStore(List<AudioFileDTO> audioList)
        {
            _audioListStore = new BindingList<AudioFileDTO>(audioList);
            _audioListStoreChange = new BindingList<AudioFileDTO>(new List<AudioFileDTO>(audioList));
            _bindingAudioListStore.DataSource = _audioListStore;
            dataGridViewStore.DataSource = _bindingAudioListStore;
            dataGridViewStore.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewStore.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewStore.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewStore.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void buttonMoveDownAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore.Where(x => x.select == true).Count() > 1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar un solo elemento."));
                return;
            }

            int itemIndex = _audioListStore.IndexOf(_audioListStore.Where(x => x.select == true).FirstOrDefault());
            if (itemIndex > -1 && itemIndex < _audioListStore.Count() - 1)
            {
                Swap(itemIndex, itemIndex + 1);
            }
        }

        private void buttonMoveUpAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore.Where(x => x.select == true).Count() > 1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar un solo elemento."));
                return;
            }

            int itemIndex = _audioListStore.IndexOf(_audioListStore.Where(x => x.select == true).FirstOrDefault());
            if (itemIndex > -1 && itemIndex != 0)
            {
                Swap(itemIndex, itemIndex - 1);
            }
        }

        private void Swap(int i, int j)
        {
            AudioFileDTO temp = _audioListStore[i];
            _audioListStore[i] = _audioListStore[j];
            _audioListStore[j] = temp;
        }

        private void buttonDeleteAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore != null && _audioListStore.Count > 0)
            {
                for (int j = _audioListStore.Count - 1; j > -1; j--)
                {
                    if (_audioListStore[j].select)
                    {
                        _audioListStore.RemoveAt(j);
                    }
                }
                dataGridViewStore.Refresh();
                UpdateStoreStadistics();
            }
        }

        private void buttonDeleteAllAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore != null && _audioListStore.Count > 0)
            {
                while (_audioListStore.Count > 0)
                {
                    _audioListStore.RemoveAt(0);
                }
                dataGridViewStore.Refresh();
                UpdateStoreStadistics();
            }
        }

        private void buttonUploadAudioListStore_Click(object sender, EventArgs e)
        {
            if (AreTheyChangesToUpload())
            {
                var op = new List<Operation> {
                    new Operation(OperationTypes.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO, ((Store)comboBoxStore.SelectedItem).code, _audioListStore.ToList()),
                    new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>())
                };

                LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
            }
            else
            {
                _raiseRichTextInsertMessage(this, (false, "No hay cambios en la lista de audio de tienda."));
            }
        }

        private bool AreTheyChangesToUpload()
        {
            if (JsonSerializer.Serialize(_audioListStore) != JsonSerializer.Serialize(_audioListStoreChange))
            {
                return true;
            }
            return false;
        }

        private void buttonRefreshListStore_Click(object sender, EventArgs e)
        {
            comboBoxStore_SelectedIndexChanged(this, null);
        }

        private void buttonUnselectAllAudioListStore_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                _audioListStore[val].select = false;
            }
            dataGridViewStore.Refresh();
        }

        private void buttonSelectAllAudioListStore_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                _audioListStore[val].select = true;
            }
            dataGridViewStore.Refresh();
        }

        private void dataGridViewServer_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewServer.ClearSelection();
        }

        private void dataGridViewStore_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewStore.ClearSelection();
        }
    }
}
