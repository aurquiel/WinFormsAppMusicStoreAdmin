using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Windows.Forms;
using WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlMusic : UserControl
    {
        private FormOperationAndWait _formOperationAndWait;

        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private List<Store> _stores;
        private BindingSource _bindingAudioListServer = new BindingSource();
        private BindingSource _bindingAudioListStore = new BindingSource();
        private BindingList<AudioFileSelect> _audioListServer = new BindingList<AudioFileSelect>();
        private bool _audioListServerDownloaded = false;
        private BindingList<AudioFileSelect> _audioListStore = new BindingList<AudioFileSelect>();
        private bool _audioListStoreDownloaded = false;

        private enum OPERATION_UPDATE { NONE = 0, SERVER = 1, STORE = 2 }
        private readonly string PREFIX_PUBLICITY = "@PUBLICIDAD_";
        private readonly string PREFIX_TIME = "@TIEMPO_";

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
        ToolTip toolTipButtonArrangePublicity = new ToolTip();
        ToolTip toolTipButtonMoveDown = new ToolTip();
        ToolTip toolTipButtonMoveUp = new ToolTip();
        ToolTip toolTipButtonDeleteAudioAudioListStore = new ToolTip();
        ToolTip toolTipButtonDeleteAllAudioAudioListStore = new ToolTip();
        ToolTip toolTipButtonPushToServer = new ToolTip();

        public UserControlMusic(FormOperationAndWait formOperationAndWait, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            SetDoubleBuffered();
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _formOperationAndWait = formOperationAndWait;
            _formOperationAndWait.SuscribeRichTextEvent(_raiseRichTextInsertMessage);
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

        private void SetDoubleBuffered()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null, this.dataGridViewServer, new object[] { true });
            typeof(DataGridView).InvokeMember("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null, this.dataGridViewStore, new object[] { true });
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
            toolTipButtonArrangePublicity.SetToolTip(buttonArrangePublicity, "Ordenar publicidad.");
            toolTipButtonMoveDown.SetToolTip(buttonMoveDownAudioListStore, "Desplazar abajo.");
            toolTipButtonMoveUp.SetToolTip(buttonMoveUpAudioListStore, "Desplazar arriba.");
            toolTipButtonDeleteAudioAudioListStore.SetToolTip(buttonDeleteAudioAudioListStore, "Eliminar Audio.");
            toolTipButtonDeleteAllAudioAudioListStore.SetToolTip(buttonDeleteAllAudioAudioListStore, "Elimnar todos los audios.");
            toolTipButtonPushToServer.SetToolTip(buttonUploadAudioListStore, "Guardar cambios en el servidor.");
        }

        private void LoadComboBoxStores()
        {
            comboBoxStore.SelectedIndexChanged -= comboBoxStore_SelectedIndexChanged;
            comboBoxStore.DataSource = _stores.Where(x => x.Code != "0000").ToList();
            comboBoxStore.DisplayMember = "code";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.SelectedIndex = -1;
            comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
        }

        private void LaunchOperationWaitForm(List<Operation> operations, OPERATION_UPDATE update)
        {
            _formOperationAndWait.AudioFileListDownloaded = new List<AudioFileSelect>();
            _formOperationAndWait.Operations = operations;
            _formOperationAndWait.ShowDialog();

            if (update == OPERATION_UPDATE.SERVER)
            {
                if (_formOperationAndWait.AudioFileListDownloaded != null)
                {
                    _audioListServerDownloaded = true;
                    BindListboxServer(_formOperationAndWait.AudioFileListDownloaded);
                }
                else
                {
                    _audioListServerDownloaded = false;
                }
                UpdateServerStadistics();
            }
            else if (update == OPERATION_UPDATE.STORE)
            {
                if (_formOperationAndWait.AudioFileListDownloaded != null)
                {
                    _audioListStoreDownloaded = true;
                    BindListboxStore(_formOperationAndWait.AudioFileListDownloaded);
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

        private void BindListboxServer(List<AudioFileSelect> audioFileList)
        {
            _audioListServer = new BindingList<AudioFileSelect>(audioFileList);
            _bindingAudioListServer.DataSource = _audioListServer;
            dataGridViewServer.DataSource = _bindingAudioListServer;
        }

        private void buttonPullAudioFromServer_Click(object sender, EventArgs e)
        {
            var operation = new List<Operation> { new Operation(OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST, new Store(), new List<AudioFileSelect>()) };
            LaunchOperationWaitForm(operation, OPERATION_UPDATE.SERVER);
            UpdateServerStadistics();
        }

        private void UpdateServerStadistics()
        {
            TimeSpan acumulateTime = new TimeSpan();
            double totalSize = 0;
            foreach (var item in _audioListServer)
            {
                totalSize += item.Size;
                acumulateTime = acumulateTime.Add(item.Duration);
            }
            labeServerStadistics.Text = $"Lista Servidor: Audios: {_audioListServer.Count}  Peso Mb: {totalSize.ToString("0.##")} Tiempo: {acumulateTime}";
        }

        private void UpdateStoreStadistics()
        {
            TimeSpan acumulateTime = new TimeSpan();
            double totalSize = 0;
            foreach (var item in _audioListStore)
            {
                totalSize += item.Size;
                acumulateTime = acumulateTime.Add(item.Duration);
            }
            labelStoreStadictics.Text = $"Lista Tienda: {((Store)comboBoxStore.SelectedItem).Code} Audios: {_audioListStore.Count}  Peso Mb: {totalSize.ToString("0.##")} Tiempo: {acumulateTime}";
        }

        private void buttonRemoveAudioFromServer_Click(object sender, EventArgs e)
        {
            if (_audioListServerDownloaded)
            {
                List<AudioFileSelect> audioFilesToDelete = new List<AudioFileSelect>();
                foreach (var audioFile in _audioListServer)
                {
                    if (audioFile.Select)
                    {
                        audioFilesToDelete.Add(audioFile);
                    }
                }

                if (audioFilesToDelete.Count > 0)
                {
                    List<Operation> op = new List<Operation>(){
                        new Operation(OperationTypes.OPERATIONS.SERVER_DELETE_AUDIO, new Store(), audioFilesToDelete),
                        new Operation(OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST, new Store(), new List<AudioFileSelect>())
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
                _audioListServer[val].Select = false;
            }
            dataGridViewServer.Refresh();
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListServer.Count; val++)
            {
                _audioListServer[val].Select = true;
            }
            dataGridViewServer.Refresh();
        }

        private void buttonSelectAllAudio_Click(object sender, EventArgs e)
        {
            buttonUnselectAll_Click(null, null);
            for (int val = 0; val < _audioListServer.Count; val++)
            {
                if (!_audioListServer[val].Name.Contains(PREFIX_PUBLICITY) && !_audioListServer[val].Name.Contains(PREFIX_TIME))
                {
                    _audioListServer[val].Select = true;
                }
            }
            dataGridViewServer.Refresh();
        }

        private void buttonSelectAllPublicity_Click(object sender, EventArgs e)
        {
            buttonUnselectAll_Click(null, null);
            for (int val = 0; val < _audioListServer.Count; val++)
            {
                if (_audioListServer[val].Name.Contains(PREFIX_PUBLICITY))
                {
                    _audioListServer[val].Select = true;
                }
            }
            dataGridViewServer.Refresh();
        }

        private void buttonSelectAllTime_Click(object sender, EventArgs e)
        {
            buttonUnselectAll_Click(null, null);
            for (int val = 0; val < _audioListServer.Count; val++)
            {
                if (_audioListServer[val].Name.Contains(PREFIX_TIME))
                {
                    _audioListServer[val].Select = true;
                }
            }
            dataGridViewServer.Refresh();
        }

        private void buttonAddAudiosToServer_Click(object sender, EventArgs e)
        {
            if (_audioListServerDownloaded)
            {
                var filesPath = GetFilePathFromDialog();
                var audioFilesToUpload = new List<AudioFileSelect>();
                if (filesPath.Count() > 0)
                {
                    foreach (var file in filesPath)
                    {
                        if (_audioListServer.Any(x => x.Name == Path.GetFileName(file)))
                        {
                            _raiseRichTextInsertMessage?.Invoke(this, (false, "Archivo de audio ya existente en la lista. Audio: " + Path.GetFileName(file)));
                        }
                        else
                        {
                            audioFilesToUpload.Add(new AudioFileSelect { Name = Path.GetFileName(file), Path = file });
                        }
                    }
                }

                if (audioFilesToUpload.Count() > 0)
                {
                    List<Operation> op = new List<Operation>(){
                        new Operation(OperationTypes.OPERATIONS.SERVER_UPLOAD_AUDIO, new Store(), audioFilesToUpload),
                        new Operation(OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST, new Store(), new List<AudioFileSelect>())
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
            var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.SERVER_SYNCHRONIZE_STORES, new Store(), new List<AudioFileSelect>()) };
            LaunchOperationWaitForm(op, OPERATION_UPDATE.NONE);
        }

        private void buttonAddAudioToAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStoreDownloaded)
            {
                int index = 1;
                foreach (var audioserver in _audioListServer)
                {
                    if (audioserver.Select)
                    {
                        _audioListStore.Add(
                            new AudioFileSelect
                            {
                                Select = false,
                                Order = ++index,
                                StoreId = ((Store)comboBoxStore.SelectedItem).Id,
                                Name = audioserver.Name,
                                Path = audioserver.Path,
                                Duration = audioserver.Duration,
                                Size = audioserver.Size,
                                CheckForTime = audioserver.Name.Contains(PREFIX_TIME) ? true : false,
                                TimeToPlay = audioserver.TimeToPlay
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
                var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem), new List<AudioFileSelect>()) };
                LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
            }
        }

        private void BindListboxStore(List<AudioFileSelect> audioList)
        {
            _audioListStore = new BindingList<AudioFileSelect>(audioList);
            _bindingAudioListStore.DataSource = _audioListStore;
            dataGridViewStore.DataSource = _bindingAudioListStore;
            dataGridViewStore.Columns[8].DefaultCellStyle.Format = "hh\\:mm\\:ss";
        }

        private void buttonMoveDownAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore.Where(x => x.Select == true).Count() > 1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar un solo elemento."));
                return;
            }

            int itemIndex = _audioListStore.IndexOf(_audioListStore.Where(x => x.Select == true).FirstOrDefault());
            if (itemIndex > -1 && itemIndex < _audioListStore.Count() - 1)
            {
                Swap(itemIndex, itemIndex + 1);
            }
        }

        private void buttonMoveUpAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore.Where(x => x.Select == true).Count() > 1)
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Error debe seleccionar un solo elemento."));
                return;
            }

            int itemIndex = _audioListStore.IndexOf(_audioListStore.Where(x => x.Select == true).FirstOrDefault());
            if (itemIndex > -1 && itemIndex != 0)
            {
                Swap(itemIndex, itemIndex - 1);
            }
        }

        private void Swap(int i, int j)
        {
            AudioFileSelect temp = _audioListStore[i];
            _audioListStore[i] = _audioListStore[j];
            _audioListStore[j] = temp;
        }

        private void buttonArrangePublicity_Click(object sender, EventArgs e)
        {
            if (_audioListStore.Count > 0)
            {
                List<AudioFileSelect> arrangedList = ArrangeAudioList(_audioListStore.ToList());
                BindListboxStore(arrangedList);
            }
        }

        private List<AudioFileSelect> ArrangeAudioList(List<AudioFileSelect> audioList)
        {
            List<AudioFileSelect> onlySongs = audioList.Where(x => !x.Name.Contains(PREFIX_PUBLICITY) && x.CheckForTime == false).ToList();
            List<AudioFileSelect> onlyPublicity = audioList.Where(x => x.Name.Contains(PREFIX_PUBLICITY) && x.CheckForTime == false).ToList();
            List<AudioFileSelect> onlyTime = audioList.Where(x => x.CheckForTime == true).ToList();
            List<AudioFileSelect> arrangedList = new List<AudioFileSelect>();
            int padding = 0;

            if (onlySongs.Count == 0)
            {
                return onlyPublicity;
            }

            if (onlyPublicity.Count == 0)
            {
                return onlySongs;
            }

            if (onlySongs.Count >= onlyPublicity.Count)
            {
                padding = (int)Math.Floor((decimal)onlySongs.Count / onlyPublicity.Count);

                if (onlySongs.Count == 1)
                {
                    padding = padding / 2;
                    for (int i = 0; i < onlySongs.Count; i++)
                    {
                        arrangedList.Add(onlySongs[i]);
                    }
                    arrangedList.Insert(padding, onlyPublicity[0]);
                    return arrangedList;
                }

                for (int i = 0, j = 0, k = 0; i < onlySongs.Count; i++)
                {
                    if (j < padding)
                    {
                        arrangedList.Add(onlySongs[i]);
                        j++;
                    }
                    else if (k < onlyPublicity.Count)
                    {
                        i--;
                        arrangedList.Add(onlyPublicity[k]);
                        k++;
                        j = 0;
                    }

                    if (i + 1 >= onlySongs.Count && k < onlyPublicity.Count)
                    {
                        arrangedList.Add(onlyPublicity[k]);
                    }

                    if (j == padding && k >= onlyPublicity.Count)
                    {
                        j = 0;
                    }
                }

                int lastIndexPublicity = arrangedList.FindLastIndex(x => x.Name.Contains("@PUBLICIDAD_"));

                if (lastIndexPublicity == arrangedList.Count - 1)
                {
                    return arrangedList;
                }

                List<AudioFileSelect> orphanSongs = new List<AudioFileSelect>();

                for (int i = lastIndexPublicity + 1; i < arrangedList.Count; i++)
                {
                    orphanSongs.Add(arrangedList[i]);
                }

                for (int j = arrangedList.Count - 1; j > lastIndexPublicity; j--)
                {
                    arrangedList.RemoveAt(j);
                }

                List<int> indexes = new List<int>();
                for (int i = 0; i < arrangedList.Count; i++)
                {
                    if (arrangedList[i].Name.Contains("@PUBLICIDAD_"))
                    {
                        indexes.Add(i);
                    }
                }

                for (int i = 0; i < orphanSongs.Count; i++)
                {
                    arrangedList.Insert(indexes[i], orphanSongs[i]);
                    for (int j = 0; j < indexes.Count; j++)
                    {
                        indexes[j]++;
                    }
                }

                foreach (var item in onlyTime)
                {
                    arrangedList.Add(item);
                }
            }
            else
            {
                padding = (int)Math.Floor((decimal)onlyPublicity.Count / onlySongs.Count);

                for (int i = 0, j = 0, k = 0; i < onlyPublicity.Count; i++)
                {
                    if (j < padding)
                    {
                        arrangedList.Add(onlyPublicity[i]);
                        j++;
                    }
                    else if (k < onlySongs.Count)
                    {
                        i--;
                        arrangedList.Add(onlySongs[k]);
                        k++;
                        j = 0;
                    }

                    if (i + 1 >= onlyPublicity.Count && k < onlySongs.Count)
                    {
                        arrangedList.Add(onlySongs[k]);
                    }

                    if (j == padding && k >= onlySongs.Count)
                    {
                        j = 0;
                    }
                }

                int lastIndexSongs = arrangedList.FindLastIndex(x => !x.Name.Contains("@PUBLICIDAD_"));

                if (lastIndexSongs == arrangedList.Count - 1)
                {
                    return arrangedList;
                }

                List<AudioFileSelect> orphanPublicity = new List<AudioFileSelect>();

                for (int i = lastIndexSongs + 1; i < arrangedList.Count; i++)
                {
                    orphanPublicity.Add(arrangedList[i]);
                }

                for (int j = arrangedList.Count - 1; j > lastIndexSongs; j--)
                {
                    arrangedList.RemoveAt(j);
                }

                List<int> indexes = new List<int>();
                for (int i = 0; i < arrangedList.Count; i++)
                {
                    if (!arrangedList[i].Name.Contains("@PUBLICIDAD_"))
                    {
                        indexes.Add(i);
                    }
                }

                for (int i = 0; i < orphanPublicity.Count; i++)
                {
                    arrangedList.Insert(indexes[i], orphanPublicity[i]);
                    for (int j = 0; j < indexes.Count; j++)
                    {
                        indexes[j]++;
                    }
                }

                foreach (var item in onlyTime)
                {
                    arrangedList.Add(item);
                }
            }

            return arrangedList;
        }

        private void buttonDeleteAudioListStore_Click(object sender, EventArgs e)
        {
            if (_audioListStore != null && _audioListStore.Count > 0)
            {
                for (int j = _audioListStore.Count - 1; j > -1; j--)
                {
                    if (_audioListStore[j].Select)
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
            int index = 1;
            foreach (var item in _audioListStore)
            {
                item.Id = 0;
                item.Order = ++index;
            }
            var op = new List<Operation> {
                new Operation(OperationTypes.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO, ((Store)comboBoxStore.SelectedItem), _audioListStore.ToList()),
                new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem), new List<AudioFileSelect>())
            };

            LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
        }

        private void buttonRefreshListStore_Click(object sender, EventArgs e)
        {
            comboBoxStore_SelectedIndexChanged(this, null);
        }

        private void buttonUnselectAllAudioListStore_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                _audioListStore[val].Select = false;
            }
            dataGridViewStore.Refresh();
        }

        private void buttonSelectAllAudioListStore_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                _audioListStore[val].Select = true;
            }
            dataGridViewStore.Refresh();
        }

        private void buttonSelectAllAudioAudioListStore_Click(object sender, EventArgs e)
        {
            buttonUnselectAllAudioListStore_Click(null, null);
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                if (!_audioListStore[val].Name.Contains(PREFIX_PUBLICITY))
                {
                    _audioListStore[val].Select = true;
                }
            }
            dataGridViewStore.Refresh();
        }

        private void buttonSelectAllPublicityAudioListStore_Click(object sender, EventArgs e)
        {
            buttonUnselectAllAudioListStore_Click(null, null);
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                if (_audioListStore[val].Name.Contains(PREFIX_PUBLICITY))
                {
                    _audioListStore[val].Select = true;
                }
            }
            dataGridViewStore.Refresh();
        }

        private void buttonSelectAllTimeAudioListStore_Click(object sender, EventArgs e)
        {
            buttonUnselectAllAudioListStore_Click(null, null);
            for (int val = 0; val < _audioListStore.Count; val++)
            {
                if (_audioListStore[val].Name.Contains(PREFIX_TIME))
                {
                    _audioListStore[val].Select = true;
                }
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
