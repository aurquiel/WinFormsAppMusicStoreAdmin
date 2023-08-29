using ChainOfResponsibilityClassLibrary;
using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryPlayer;
using ClassLibraryServices;
using System.ComponentModel;
using static ChainOfResponsibilityClassLibrary.OperationTypes;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class UserControlPlayer : UserControl
    {
        private IServices _services;
        private IFileManager _fileManager;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private List<Store> _stores;

        private BindingSource _bindingAudioListPlayer = new BindingSource();
        private BindingList<AudioFileDTO> _audioListPlayer = new BindingList<AudioFileDTO>();

        private Player _player;
        private EventHandler _playNextAudio;
        private System.Windows.Forms.Timer _timer = new System.Windows.Forms.Timer();
        private int numberOfErros = 0;


        //Tooltips
        ToolTip toolTipButtonPullFromServer = new ToolTip();
        ToolTip toolTipButtonPlay = new ToolTip();
        ToolTip toolTipButtonPause = new ToolTip();
        ToolTip toolTipButtonStop = new ToolTip();


        public UserControlPlayer(IServices services, IFileManager fileManager, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            WireUpEvents();
            CreateToolTips();
            _services = services;
            _fileManager = fileManager;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _player = new Player(_playNextAudio, _raiseRichTextInsertMessage);
            _stores = stores;
            LoadComboBoxStore();
            trackBarVolume.Value = trackBarVolume.Maximum;
            _timer.Interval = 200;
            _timer.Tick += new EventHandler(TimerEventProcessor);
            _timer.Start();
        }

        private void WireUpEvents()
        {
            this._playNextAudio += PlayNextAudioEvent;
        }

        private void PlayNextAudioEvent(object sender, object e)
        {
            PlayNextAudio();
        }

        private void LoadComboBoxStore()
        {
            comboBoxStore.SelectedIndexChanged -= comboBoxStore_SelectedIndexChanged;
            comboBoxStore.DataSource = _stores.Where(x => x.code != "0000").ToList();
            comboBoxStore.DisplayMember = "code";
            comboBoxStore.ValueMember = "id";
            comboBoxStore.SelectedIndex = -1;
            comboBoxStore.SelectedIndexChanged += comboBoxStore_SelectedIndexChanged;
        }

        private void comboBoxStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                LoadAudioListFromBinaryFile();
            }
        }

        private void LaunchOperationWaitForm(List<Operation> operations)
        {
            FormOperationAndWait formWait = new FormOperationAndWait(
                _services,
                _fileManager,
                operations,
                _raiseRichTextInsertMessage);
            formWait.ShowDialog();

            if (formWait.AudioFileListDownloaded != null)
            {
                BindListbox(formWait.AudioFileListDownloaded);
                listBoxAudio.ClearSelected();
            }
            else
            {
                _audioListPlayer.Clear();
            }
        }

        private void LoadAudioListFromBinaryFile()
        {
            _player.Stop();
            progressBarAudio.Value = 0;
            labelTotalTime.Text = "00:00";
            labelCurrentTime.Text = "00:00";
            var op = new List<Operation> {
                new Operation (OPERATIONS.PLAYER_GET_AUDIO_LIST_STORE_PC, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>())
            };
            LaunchOperationWaitForm(op);
        }

        private void buttonPullFromServer_Click(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                _player.Stop();
                progressBarAudio.Value = 0;
                labelTotalTime.Text = "00:00";
                labelCurrentTime.Text = "00:00";
                var op = new List<Operation> {
                new Operation(OPERATIONS.PLAYER_GET_AUDIO_LIST_STORE_SERVER, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>())
                };
                LaunchOperationWaitForm(op);
            }
            else
            {
                _raiseRichTextInsertMessage?.Invoke(this, (false, "Debe seleccionar una tienda."));
            }
        }

        private void CreateToolTips()
        {
            toolTipButtonPullFromServer.SetToolTip(buttonPullFromServer, "Actualizar lista de reproduccion.");
            toolTipButtonPlay.SetToolTip(buttonPlay, "Reproducir audio.");
            toolTipButtonPause.SetToolTip(buttonPause, "Pausar reproduccion.");
            toolTipButtonStop.SetToolTip(buttonStop, "Detener lista de audio.");
        }

        void TimerEventProcessor(object sender, EventArgs e)
        {
            if (_player.IsPlaying())
            {
                progressBarAudio.Maximum = (int)_player.GetLength();
                labelTotalTime.Text = _player.TotalTime().ToString("mm\\:ss");
                int pos = (int)_player.GetPosition();
                progressBarAudio.Value = pos > progressBarAudio.Maximum ? progressBarAudio.Maximum : pos;
                labelCurrentTime.Text = _player.CurrentTime().ToString("mm\\:ss");
            }
        }

        private void BindListbox(List<AudioFileDTO> audioOperationList)
        {
            _audioListPlayer = new BindingList<AudioFileDTO>(audioOperationList);
            _bindingAudioListPlayer.DataSource = _audioListPlayer;
            listBoxAudio.DataSource = _bindingAudioListPlayer;
            listBoxAudio.DisplayMember = "name";
        }
        private void PlayNextAudio()
        {
            if (numberOfErros >= listBoxAudio.Items.Count)
            {
                numberOfErros = 0;
                return;
            }

            bool flag = false;
            if (listBoxAudio.SelectedIndex < listBoxAudio.Items.Count - 1)
            {
                flag = true;
                listBoxAudio.SelectedIndex = listBoxAudio.SelectedIndex + 1;
            }
            else if (listBoxAudio.Items.Count > 0)
            {
                flag = true;
                listBoxAudio.SelectedIndex = 0;
            }

            if (flag)
            {
                buttonPlay_Click(null, null);
            }
        }

        private async void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listBoxAudio.Items.Count > 0 && listBoxAudio.SelectedItems.Count == 0)
            {
                listBoxAudio.SelectedIndex = 0;
            }

            var selectedItem = listBoxAudio.SelectedItem;
            if (selectedItem != null)
            {
                MaxNumberOfErrors(await _player.Play(((AudioFileDTO)selectedItem).path));
            }
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            _player.Pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (listBoxAudio.Items.Count > 0)
            {
                listBoxAudio.SelectedIndex = 0;
            }
            _player.Stop();
            progressBarAudio.Value = 0;
            labelCurrentTime.Text = "00:00";
            labelTotalTime.Text = "00:00";
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            _player.SetVolume(trackBarVolume.Value / (double)100);
        }

        private async void listBoxAudio_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxAudio.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                _player.Stop();
                var selectedItem = listBoxAudio.SelectedItem;
                if (selectedItem != null)
                {
                    MaxNumberOfErrors(await _player.Play(((AudioFileDTO)selectedItem).path));
                }
            }
        }

        private void progressBarAudio_MouseDown(object sender, MouseEventArgs e)
        {
            if (_player.IsPlaying())
            {
                _player.Seek(_player.GetLength() * e.X / progressBarAudio.Width);
            }
        }

        private void MaxNumberOfErrors(bool playStatus)
        {
            if(playStatus)
            {
                numberOfErros = 0;
            }
            else
            {
                numberOfErros++;
            }
        }
    }
}
