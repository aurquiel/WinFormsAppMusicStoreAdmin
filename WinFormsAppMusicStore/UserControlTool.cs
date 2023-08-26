using ChainOfResponsibilityClassLibrary;
using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using System.ComponentModel;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlTool : UserControl
    {
        private IServices _services;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private IFileManager _fileManager;
        private List<Store> _stores;
        private BindingSource _bindingAudioListStore = new BindingSource();
        private BindingList<AudioFileDTO> _audioListStore = new BindingList<AudioFileDTO>();
        private bool _audioListStoreDownloaded = false;


        private enum OPERATION_UPDATE { NONE = 0, SERVER = 1, STORE = 2 }

        //Tooltips
        ToolTip toolTipButtonRefreshAudioListStore = new ToolTip();
        ToolTip toolTipButtonUnselectAll = new ToolTip();
        ToolTip toolTipButtonSelectAll = new ToolTip();
        ToolTip toolTipButtonPushToServer = new ToolTip();

        public UserControlTool(IServices services, IFileManager fileManager, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            _services = services;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _fileManager = fileManager;
            _stores = stores;
            CreateToolTips();
            LoadComboBoxStores();
            BindListboxStore();
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
            toolTipButtonRefreshAudioListStore.SetToolTip(buttonRefreshAudioListStore, "Actualizar Lista de Audio Tienda.");
            toolTipButtonUnselectAll.SetToolTip(buttonUnselectAll, "Deseleccionar todos.");
            toolTipButtonSelectAll.SetToolTip(buttonUnselectAll, "Seleccionar todos.");
            toolTipButtonPushToServer.SetToolTip(buttonCopyAudioListToStores, "Guardar cambios en el servidor.");
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

            if (update == OPERATION_UPDATE.STORE)
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

        private void BindListboxStore(List<AudioFileDTO> audioList)
        {
            _audioListStore = new BindingList<AudioFileDTO>(audioList);
            _bindingAudioListStore.DataSource = _audioListStore;
            dataGridViewStore.DataSource = _bindingAudioListStore;
            dataGridViewStore.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewStore.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            dataGridViewStore.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
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

        private void BindListboxStore()
        {
            listBoxStores.DataSource = _stores.Where(x => x.code != "0000").ToList();
            listBoxStores.DisplayMember = "code";
            listBoxStores.ClearSelected();
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>()) };
                LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
            }
        }

        private void buttonRefreshAudioListStore_Click(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>()) };
                LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < listBoxStores.Items.Count; val++)
            {
                listBoxStores.SetSelected(val, false);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < listBoxStores.Items.Count; val++)
            {
                listBoxStores.SetSelected(val, true);
            }
        }

        private void buttonCopyAudioListToStores_Click(object sender, EventArgs e)
        {
            if (_audioListStoreDownloaded)
            {
                var selectedItems = listBoxStores.SelectedItems;
                var op = new List<Operation>();
                foreach (var item in selectedItems)
                {
                    op.Add(new Operation(OperationTypes.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO, ((Store)item).code, _audioListStore.ToList()));
                }

                LaunchOperationWaitForm(op, OPERATION_UPDATE.NONE);
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "No se ha descargado una lista de audio de una tienda."));
            }
        }

        private void dataGridViewStore_SelectionChanged(object sender, EventArgs e)
        {
            dataGridViewStore.ClearSelection();
        }
    }
}
