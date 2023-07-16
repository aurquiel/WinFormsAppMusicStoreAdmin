using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using System.ComponentModel;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsAppMusicStore
{
    public partial class UserControlMusic : UserControl
    {
        private IServices _services;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private IFileManager _fileManager;
        private BindingSource _bindingAudioListOperationList = new BindingSource();
        private BindingList<AudioOperation> _audioOperationList;
        private List<AudioOperation> _audioOperationListCompareChanges;

        //Tooltips
        ToolTip toolTipButtonPullFromServer = new ToolTip();
        ToolTip toolTipButtonMoveDown = new ToolTip();
        ToolTip toolTipButtonMoveUp = new ToolTip();
        ToolTip toolTipButtonRemove = new ToolTip();
        ToolTip toolTipButtonRemoveAll = new ToolTip();
        ToolTip toolTipButtonAdd = new ToolTip();
        ToolTip toolTipButtonPushToServer = new ToolTip();


        public UserControlMusic(IServices services, IFileManager fileManager, EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            InitializeComponent();
            _services = services;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _fileManager = fileManager;
            CreateToolTips();
            new Action(async () => await LoadAudioFromServer())();
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
            toolTipButtonPullFromServer.SetToolTip(buttonPullFromServer, "Descargar lista de audio.");
            toolTipButtonMoveDown.SetToolTip(buttonMoveDown, "Desplazar abajo.");
            toolTipButtonMoveUp.SetToolTip(buttonMoveUp, "Desplazar arriba.");
            toolTipButtonRemove.SetToolTip(buttonRemove, "Remover audio.");
            toolTipButtonRemoveAll.SetToolTip(buttonRemoveAll, "Remover todos los audios.");
            toolTipButtonAdd.SetToolTip(buttonAdd, "Agregar audio.");
            toolTipButtonPushToServer.SetToolTip(buttonPushToServer, "Guardar cambios en el servidor.");
        }

        private async Task LoadAudioFromServer()
        {
            var result = await _services.AudioService.DownloadAudioList();
            if (result.status)
            {
                var listOfSongs = result.data.Split(Environment.NewLine).ToList();
                if (listOfSongs.Count == 1 && listOfSongs[0] == string.Empty)
                {
                    listOfSongs.RemoveAt(0);
                }
                var listOfAudioOperation = listOfSongs.Select(x => new AudioOperation { Name = x, Operation = AudioOperation.OPERATIONS.NONE, PathFileUpload = string.Empty }).ToList();
                _audioOperationListCompareChanges = new List<AudioOperation>(listOfAudioOperation);
                _audioOperationList = new BindingList<AudioOperation>(listOfAudioOperation);
                BindListbox(_audioOperationList);
                _raiseRichTextInsertMessage?.Invoke(this, new(result.status, result.statusMessage));
                return;
            }

            _raiseRichTextInsertMessage?.Invoke(this, new(result.status, result.statusMessage));
        }

        private void BindListbox(BindingList<AudioOperation> audioOperationList)
        {
            _bindingAudioListOperationList.DataSource = audioOperationList;
            listBoxAudio.DataSource = _bindingAudioListOperationList;
            listBoxAudio.DisplayMember = "Name";
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            var itemIndex = listBoxAudio.SelectedIndex;
            if (itemIndex > -1 && itemIndex < listBoxAudio.Items.Count - 1)
            {
                Swap(itemIndex, itemIndex + 1);
                listBoxAudio.SelectedIndex = itemIndex + 1;
            }
        }

        private void Swap(int i, int j)
        {
            AudioOperation temp = _audioOperationList[i];
            _audioOperationList[i] = _audioOperationList[j];
            _audioOperationList[j] = temp;
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            var itemIndex = listBoxAudio.SelectedIndex;
            if (itemIndex > -1 && itemIndex != 0)
            {
                Swap(itemIndex, itemIndex - 1);
                listBoxAudio.SelectedIndex = itemIndex - 1;
            }
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (_audioOperationList != null && _audioOperationList.Count > 0)
            {
                _audioOperationList.RemoveAt(listBoxAudio.SelectedIndex);
            }
        }

        private void buttonRemoveAll_Click(object sender, EventArgs e)
        {
            if (_audioOperationList != null && _audioOperationList.Count > 0)
            {
                while (_audioOperationList.Count > 0)
                {
                    _audioOperationList.RemoveAt(0);
                }
            }
        }

        private async void buttonPullFromServer_Click(object sender, EventArgs e)
        {
            await LoadAudioFromServer();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var filesPath = GetFilePathFromDialog();
            if (filesPath.Count() > 0)
            {
                foreach (var file in filesPath)
                {
                    if (_audioOperationList.Any(x => x.Name == Path.GetFileName(file)))
                    {
                        _raiseRichTextInsertMessage?.Invoke(this, (false, "Archivo de audio ya existente en la lista."));
                    }
                    else
                    {
                        _audioOperationList.Add(new AudioOperation { Name = Path.GetFileName(file), Operation = AudioOperation.OPERATIONS.UPLOAD, PathFileUpload = file });
                        _raiseRichTextInsertMessage?.Invoke(this, (true, "Archivo de audio agregado a la lista."));
                    }
                }
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

        private bool areTheyChancehsToPush()
        {
            if (JsonSerializer.Serialize(_audioOperationList) != JsonSerializer.Serialize(_audioOperationListCompareChanges))
            {
                return true;
            }
            return false;
        }

        private async void buttonPushToServer_Click(object sender, EventArgs e)
        {
            if (areTheyChancehsToPush())
            {
                FormWait form = new FormWait(_services, _fileManager, new List<AudioOperation>(_audioOperationList), _raiseRichTextInsertMessage, true);
                form.ShowDialog();
                await LoadAudioFromServer();
            }
            else
            {
                _raiseRichTextInsertMessage(this, (false, "No hay cambios en la lista de audio."));
            }
        }
    }
}
