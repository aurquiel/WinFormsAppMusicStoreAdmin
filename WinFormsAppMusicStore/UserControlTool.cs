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
        private BindingSource _bindingAudioListServer = new BindingSource();
        private BindingSource _bindingAudioListStore = new BindingSource();
        private BindingList<OperationDetails> _audioListFromStore = new BindingList<OperationDetails>();
        private bool _audioListServerDownloaded = false;
        private BindingList<OperationDetails> _storeList = new BindingList<OperationDetails>();
        private bool _audioListStoreDownloaded = false;

        private enum OPERATION_UPDATE { NONE = 0, SERVER = 1 }

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
                    BindListboxAudioListStore(formWait.AudioList);
                    listBoxAudioListStore.ClearSelected();
                }
                else
                {
                    _audioListServerDownloaded = false;
                }
            }
        }

        private void BindListboxAudioListStore(List<OperationDetails> audioList)
        {
            _audioListFromStore = new BindingList<OperationDetails>(audioList);
            _bindingAudioListServer.DataSource = _audioListFromStore;
            listBoxAudioListStore.DataSource = _bindingAudioListServer;
            listBoxAudioListStore.DisplayMember = "AudioName";
        }

        private void BindListboxStore()
        {
            listBoxStores.DataSource = _stores.Where(x => x.code != "0000").ToList();
            listBoxStores.DisplayMember = "code";
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var operationDetails = new List<OperationDetails> { new OperationDetails { Operation = OperationDetails.OPERATIONS.STORE_GET_AUDIO_LIST, StoreCode = ((Store)comboBoxStore.SelectedItem).code } };
                LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.SERVER);
            }
        }

        private void buttonRefreshAudioListStore_Click(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var operationDetails = new List<OperationDetails> { new OperationDetails { Operation = OperationDetails.OPERATIONS.STORE_GET_AUDIO_LIST, StoreCode = ((Store)comboBoxStore.SelectedItem).code } };
                LaunchOperationWaitForm(operationDetails, OPERATION_UPDATE.SERVER);
            }
        }

        private void buttonUnselectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < listBoxStores.Items.Count; val++)
            {
                listBoxAudioListStore.SetSelected(val, false);
            }
        }

        private void buttonSelectAll_Click(object sender, EventArgs e)
        {
            for (int val = 0; val < listBoxStores.Items.Count; val++)
            {
                listBoxAudioListStore.SetSelected(val, true);
            }
        }

        private void buttonCopyAudioListToStores_Click(object sender, EventArgs e)
        {          
            var audioListString = String.Join("\r\n", listBoxAudioListStore.Items.OfType<OperationDetails>().Select(x => x.AudioName).ToArray());
            var selectedItems = listBoxStores.SelectedItems;
            var operationDetailsList = new List<OperationDetails>();
            foreach(var item in selectedItems)
            {
                operationDetailsList.Add(new OperationDetails { StoreCode = ((Store)item).code, AudioList = audioListString, Operation = OperationDetails.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO });
            }
            LaunchOperationWaitForm(operationDetailsList, OPERATION_UPDATE.NONE);
        }
    }
}
