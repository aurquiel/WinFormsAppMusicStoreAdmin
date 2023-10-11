using ClassLibraryDomain.Models;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlTool : UserControl
    {
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private FormOperationAndWait _formOperationAndWait;
        private List<Store> _stores;
        private BindingSource _bindingAudioListStore = new BindingSource();
        private BindingList<AudioFileSelect> _audioListStore = new BindingList<AudioFileSelect>();
        private bool _audioListStoreDownloaded = false;


        private enum OPERATION_UPDATE { NONE = 0, SERVER = 1, STORE = 2 }

        //Tooltips
        ToolTip toolTipButtonRefreshAudioListStore = new ToolTip();
        ToolTip toolTipButtonUnselectAll = new ToolTip();
        ToolTip toolTipButtonSelectAll = new ToolTip();
        ToolTip toolTipButtonPushToServer = new ToolTip();

        public UserControlTool(FormOperationAndWait formOperationAndWait, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            SetDoubleBuffered();
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _formOperationAndWait = formOperationAndWait;
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

        private void SetDoubleBuffered()
        {
            typeof(DataGridView).InvokeMember("DoubleBuffered",
            BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
            null, this.dataGridViewStore, new object[] { true });
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

            if (update == OPERATION_UPDATE.STORE)
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

        private void BindListboxStore(List<AudioFileSelect> audioList)
        {
            _audioListStore = new BindingList<AudioFileSelect>(audioList);
            _bindingAudioListStore.DataSource = _audioListStore;
            dataGridViewStore.DataSource = _bindingAudioListStore;
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

        private void BindListboxStore()
        {
            listBoxStores.DataSource = _stores.Where(x => x.Code != "0000").ToList();
            listBoxStores.DisplayMember = "code";
            listBoxStores.ClearSelected();
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem), new List<AudioFileSelect>()) };
                LaunchOperationWaitForm(op, OPERATION_UPDATE.STORE);
            }
        }

        private void buttonRefreshAudioListStore_Click(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                var op = new List<Operation> { new Operation(OperationTypes.OPERATIONS.STORE_GET_AUDIO_LIST, ((Store)comboBoxStore.SelectedItem), new List<AudioFileSelect>()) };
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
                    string serialize = JsonSerializer.Serialize(_audioListStore.ToList());
                    var changedAudioList = JsonSerializer.Deserialize<List<AudioFileSelect>>(serialize);
                    foreach(var comp in changedAudioList)
                    {
                        comp.Id = 0;
                        comp.StoreId = _stores.Where(x => x.Code == item).Select(x => x.Id).FirstOrDefault();
                    }
                    op.Add(new Operation(OperationTypes.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO, ((Store)item), _audioListStore.ToList()));
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
