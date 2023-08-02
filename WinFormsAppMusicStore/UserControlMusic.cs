using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using System.ComponentModel;
using System.IO;
using System.Text.Json;

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
        private BindingList<OperationDetails> _audioListServer = new BindingList<OperationDetails>();
        private bool _audioListServerDownloaded = false;
        private BindingList<OperationDetails> _audioListStore = new BindingList<OperationDetails>();
        private bool _audioListStoreDownloaded = false;
        private BindingList<OperationDetails> _audioListStoreChange = new BindingList<OperationDetails>();

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
            toolTipButtonSelectAll.SetToolTip(buttonUnselectAll, "Seleccionar todos.");
            toolTipButtonAddAudiosToServer.SetToolTip(buttonAddAudiosToServer, "Agregar audios.");
            toolTipButtonSynchronizeAllStores.SetToolTip(buttonSynchronizeAllStores, "Sincronizar lista de audio de las tiendas.");
            toolTipButtonAddAudioToAudioListStore.SetToolTip(buttonAddAudioToAudioListStore, "Agregar Audios a Lista de Audio Tienda.");
            toolTipButtonRefreshListStore.SetToolTip(buttonRefreshListStore, "Actualizar a Lista de Audio Tienda.");
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

        private void LaunchOperationWaitForm(List<OperationDetails> operationDetails, OPERATION_UPDATE update)
        {
            FormOperationAndWait formWait = new FormOperationAndWait(
                _services,
                _fileManager,
                operationDetails,
                _raiseRichTextInsertMessage);
            formWait.ShowDialog();

            if (update == OPERATION_UPDATE.SERVER)
            {
                if (formWait.AudioList != null)
                {
                    _audioListServerDownloaded = true;
                    BindListboxServer(formWait.AudioList);
                    listBoxAudioListServer.ClearSelected();
                }
                else
                {
                    _audioListServerDownloaded = false;
                }
            }
            else if (update == OPERATION_UPDATE.STORE)
            {
                if (formWait.AudioList != null)
                {
                    _audioListStoreDownloaded = true;
                    BindListboxStore(formWait.AudioList);
                    listBoxAudioListStore.ClearSelected();
                    labelAudioListStoreCode.Text = $"LISTA DE AUDIO TIENDA: {((Store)comboBoxStore.SelectedItem).code}";
                }
                else
                {
                    _audioListStoreDownloaded = false;
                    _audioListStore.Clear();
                    labelAudioListStoreCode.Text = "LISTA DE AUDIO TIENDA: 0000";
                    comboBoxStore.SelectedIndexChanged -= comboBoxStore_SelectedIndexChanged;
                    comboBoxStore.SelectedIndex = -1;
                    comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
                }
            }
        }

        private void BindListboxServer(List<OperationDetails> audioList)
        {
            _audioListServer = new BindingList<OperationDetails>(audioList);
            _bindingAudioListServer.DataSource = _audioListServer;
            listBoxAudioListServer.DataSource = _bindingAudioListServer;
            listBoxAudioListServer.DisplayMember = "AudioName";
        }

        private void buttonPullAudioFromServer_Click(object sender, EventArgs e)
        {
            var operationDetails = new List<OperationDetails> { new OperationDetails { Operation = OperationDetails.OPERATIONS.SERVER_GET_AUDIO_LIST } };
            LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.SERVER);

        }

        private void buttonRemoveAudioFromServer_Click(object sender, EventArgs e)
        {
            if (_audioListServerDownloaded)
            {
                List<OperationDetails> operationDetails = new List<OperationDetails>();
                var itemsSerlectd = listBoxAudioListServer.SelectedItems;
                foreach (var item in itemsSerlectd)
                {
                    ((OperationDetails)item).Operation = OperationDetails.OPERATIONS.SERVER_DELETE_AUDIO;
                    operationDetails.Add((OperationDetails)item);
                }

                operationDetails.Add(new OperationDetails { Operation = OperationDetails.OPERATIONS.SERVER_GET_AUDIO_LIST });

                if (operationDetails.Count > 0)
                {
                    LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.SERVER);
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
            for (int val = 0; val < listBoxAudioListServer.Items.Count; val++)
            {
                listBoxAudioListServer.SetSelected(val, false);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < listBoxAudioListServer.Items.Count; val++)
            {
                listBoxAudioListServer.SetSelected(val, true);
            }
        }

        private void buttonAddAudiosToServer_Click(object sender, EventArgs e)
        {
            if (_audioListServerDownloaded)
            {
                var filesPath = GetFilePathFromDialog();
                var operationDetails = new List<OperationDetails>();
                if (filesPath.Count() > 0)
                {
                    foreach (var file in filesPath)
                    {
                        if (_audioListServer.Any(x => x.AudioName == Path.GetFileName(file)))
                        {
                            _raiseRichTextInsertMessage?.Invoke(this, (false, "Archivo de audio ya existente en la lista. Audio: " + Path.GetFileName(file)));
                        }
                        else
                        {
                            operationDetails.Add(new OperationDetails { AudioName = Path.GetFileName(file), Operation = OperationDetails.OPERATIONS.SERVER_UPLOAD_AUDIO, PathFileAudio = file });
                        }
                    }

                    operationDetails.Add(new OperationDetails { Operation = OperationDetails.OPERATIONS.SERVER_GET_AUDIO_LIST });
                }

                if (operationDetails.Count() > 0)
                {
                    LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.SERVER);
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
            var operationDetails = new List<OperationDetails> { new OperationDetails { Operation = OperationDetails.OPERATIONS.SERVER_SYNCHRONIZE_STORES } };
            LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.NONE);
        }

        private void buttonAddAudioToAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStoreDownloaded)
            {
                var listSelectedAudioServer = listBoxAudioListServer.SelectedItems;
                foreach (var audioServer in listSelectedAudioServer)
                {
                    if (IsAudioInAudioListStore((OperationDetails)audioServer) == false)
                    {
                        _audioListStore.Add((OperationDetails)audioServer);
                    }
                    else
                    {
                        _raiseRichTextInsertMessage?.Invoke(this, (false, "Error archivo ya en la lista de la tienda, audio: " + ((OperationDetails)audioServer).AudioName));
                    }
                }
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe descargar una lista de audio de tienda."));
            }
        }

        private bool IsAudioInAudioListStore(OperationDetails audioServer)
        {
            foreach (var item in listBoxAudioListStore.Items)
            {
                if (((OperationDetails)item).AudioName == audioServer.AudioName)
                {
                    return true;
                }
            }

            return false;
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var operationDetails = new List<OperationDetails> { new OperationDetails { Operation = OperationDetails.OPERATIONS.STORE_GET_AUDIO_LIST, StoreCode = ((Store)comboBoxStore.SelectedItem).code } };
                LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.STORE);
            }
        }

        private void BindListboxStore(List<OperationDetails> audioList)
        {
            _audioListStore = new BindingList<OperationDetails>(audioList);
            _audioListStoreChange = new BindingList<OperationDetails>(new List<OperationDetails>(audioList));
            _bindingAudioListStore.DataSource = _audioListStore;
            _bindingAudioListStore.DataSource = _audioListStore;
            listBoxAudioListStore.DataSource = _bindingAudioListStore;
            listBoxAudioListStore.DisplayMember = "AudioName";
        }

        private void buttonMoveDownAudioListStore_Click(object sender, EventArgs e)
        {
            if (listBoxAudioListStore.SelectedItems.Count > 1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar un solo elemento."));
                return;
            }

            var itemIndex = listBoxAudioListStore.SelectedIndex;
            if (itemIndex > -1 && itemIndex < listBoxAudioListStore.Items.Count - 1)
            {
                Swap(itemIndex, itemIndex + 1);
                listBoxAudioListStore.ClearSelected();
                listBoxAudioListStore.SelectedIndex = itemIndex + 1;
            }
        }

        private void buttonMoveUpAudioListStore_Click(object sender, EventArgs e)
        {
            if (listBoxAudioListStore.SelectedItems.Count > 1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar un solo elemento."));
                return;
            }

            var itemIndex = listBoxAudioListStore.SelectedIndex;
            if (itemIndex > -1 && itemIndex != 0)
            {
                Swap(itemIndex, itemIndex - 1);
                listBoxAudioListStore.ClearSelected();
                listBoxAudioListStore.SelectedIndex = itemIndex - 1;
            }
        }

        private void Swap(int i, int j)
        {
            OperationDetails temp = _audioListStore[i];
            _audioListStore[i] = _audioListStore[j];
            _audioListStore[j] = temp;
        }

        private void buttonDeleteAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore != null && _audioListStore.Count > 0)
            {
                var items = listBoxAudioListStore.SelectedIndices.Cast<int>().ToList();
                for (int j = items.Count - 1; j > -1; j--)
                {
                    int a = items[j];
                    _audioListStore.RemoveAt(a);
                }
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
            }
        }

        private void buttonUploadAudioListStore_Click(object sender, EventArgs e)
        {
            if (AreTheyChangesToUpload())
            {
                var operationDetails = new List<OperationDetails> {
                    new OperationDetails {
                        Operation = OperationDetails.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO,
                        AudioList = String.Join("\r\n",_audioListStore.Select(x => x.AudioName).ToArray()),
                        StoreCode = ((Store)comboBoxStore.SelectedItem).code
                    }
                };
                LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.STORE);
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
            for (int val = 0; val < listBoxAudioListStore.Items.Count; val++)
            {
                listBoxAudioListStore.SetSelected(val, false);
            }
        }

        private void buttonSelectAllAudioListStore_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < listBoxAudioListStore.Items.Count; val++)
            {
                listBoxAudioListStore.SetSelected(val, true);
            }
        }
    }
}
