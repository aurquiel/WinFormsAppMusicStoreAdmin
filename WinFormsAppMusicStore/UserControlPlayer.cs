using ChainOfResponsibilityClassLibrary;
using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Threading;
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

        private MediaPlayer player = new MediaPlayer();
        private bool isPaused = false;
        TimeSpan _position;
        DispatcherTimer _timer = new DispatcherTimer();

        //Tooltips
        ToolTip toolTipButtonPullFromServer = new ToolTip();
        ToolTip toolTipButtonPlay = new ToolTip();
        ToolTip toolTipButtonPause = new ToolTip();
        ToolTip toolTipButtonStop = new ToolTip();
        

        public UserControlPlayer(IServices services, IFileManager fileManager, List<Store> stores, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            CreateToolTips();
            _services = services;
            _fileManager = fileManager;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _stores = stores;
            player.MediaEnded += Player_MediaEnded;
            player.MediaFailed += Player_MediaFailed;
            player.MediaOpened += Player_MediaOpened;
            player.Volume = 1;
            trackBarVolume.Value = trackBarVolume.Maximum;
            _timer.Interval = TimeSpan.FromMilliseconds(10);
            _timer.Tick += new EventHandler(ticktock);
            _timer.Start();
            LoadComboBoxStore();
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
            InitMediaPlayer();
            var op = new List<Operation> {
                new Operation (OPERATIONS.PLAYER_GET_AUDIO_LIST_STORE_PC, ((Store)comboBoxStore.SelectedItem).code, new List<AudioFileDTO>())
            };
            LaunchOperationWaitForm(op);
        }

        private void buttonPullFromServer_Click(object sender, EventArgs e)
        {
            if (comboBoxStore.SelectedIndex != -1)
            {
                InitMediaPlayer();
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

        private void Player_MediaOpened(object? sender, EventArgs e)
        {
            _position = player.NaturalDuration.TimeSpan;
            progressBarAudio.Minimum = 0;
            progressBarAudio.Maximum = (int)_position.TotalSeconds;
        }

        private void CreateToolTips()
        {
            toolTipButtonPullFromServer.SetToolTip(buttonPullFromServer, "Actualizar lista de reproduccion.");
            toolTipButtonPlay.SetToolTip(buttonPlay, "Reproducir audio.");
            toolTipButtonPause.SetToolTip(buttonPause, "Pausar reproduccion.");
            toolTipButtonStop.SetToolTip(buttonStop, "Detener lista de audio.");
        }

        void ticktock(object sender, EventArgs e)
        {
            progressBarAudio.Value = (int)player.Position.TotalSeconds;
        }

        private void InitMediaPlayer()
        {
            player.Stop();
            player = new MediaPlayer();
            player.MediaEnded += Player_MediaEnded;
            player.MediaFailed += Player_MediaFailed;
            player.MediaOpened += Player_MediaOpened;
            player.Volume = 1;
            trackBarVolume.Value = trackBarVolume.Maximum;
        }

        private void Player_MediaFailed(object? sender, ExceptionEventArgs e)
        {
            InitMediaPlayer();
            PlayNextAudio();
            _raiseRichTextInsertMessage?.Invoke(this, (false, "Error al reproducir archvio de audio. Excepcion: " + e.ErrorException.Message));
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

        private void Player_MediaEnded(object? sender, EventArgs e)
        {
            PlayNextAudio();
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            if (listBoxAudio.Items.Count > 0 && listBoxAudio.SelectedItems.Count == 0)
            {
                listBoxAudio.SelectedIndex = 0;
            }

            if (isPaused == false)
            {
                var selectedItem = listBoxAudio.SelectedItem;
                if (selectedItem != null)
                {
                    player.Open(new Uri(((AudioFileDTO)selectedItem).path));
                }
            }
            isPaused = false;
            player.Play();
        }

        private void buttonPause_Click(object sender, EventArgs e)
        {
            isPaused = true;
            player.Pause();
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (listBoxAudio.Items.Count > 0)
            {
                listBoxAudio.SelectedIndex = 0;
            }
            player.Stop();
        }

        private void trackBarVolume_Scroll(object sender, EventArgs e)
        {
            player.Volume = (trackBarVolume.Value / (double)100);
        }

        private void listBoxAudio_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int index = this.listBoxAudio.IndexFromPoint(e.Location);
            if (index != System.Windows.Forms.ListBox.NoMatches)
            {
                player.Stop();
                var selectedItem = listBoxAudio.SelectedItem;
                if (selectedItem != null)
                {
                    player.Open(new Uri(((AudioFileDTO)selectedItem).path));
                }
                buttonPlay_Click(null, null);
            }
        }

        private void progressBarAudio_MouseDown(object sender, MouseEventArgs e)
        {
            if (player.NaturalDuration.HasTimeSpan)
            {
                player.Position = player.NaturalDuration.TimeSpan * e.X / progressBarAudio.Width;
            }
        }
    }
}
