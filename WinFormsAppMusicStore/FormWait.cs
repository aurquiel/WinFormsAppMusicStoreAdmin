using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsAppMusicStore
{
    public partial class FormWait : Form
    {
        private IServices _services;
        private IFileManager _fileManager;
        private List<AudioOperation> _audioOperationList;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private bool _isMusicPushOrMusicPull;

        public FormWait(IServices services, IFileManager fileManager, List<AudioOperation> audioOperationList, EventHandler<(bool, string)> raiseRichTextInsertMessage, bool isMusicPushOrMusicPull)
        {
            _isMusicPushOrMusicPull = isMusicPushOrMusicPull;
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            _services = services;
            _fileManager = fileManager;
            _audioOperationList = audioOperationList;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
        }

        private async void FormWait_Shown(object sender, EventArgs e)
        {
            await Task.Delay(500);
            if (_isMusicPushOrMusicPull)
            {
                await MusicPush();
            }
            else
            {

            }

            Close();
        }

        private async Task MusicPush()
        {
            await TaskPush();
            labelMessage.Text = string.Empty;
        }

        private async Task TaskPush()
        {
            var listToUpload = _audioOperationList.Where(x => x.Operation == AudioOperation.OPERATIONS.UPLOAD).ToList();
            labelTotalNumber.Text = (listToUpload.Count() + 1).ToString();
            if (listToUpload.Count() > 0)
            {
                await UploadFiles(listToUpload);
            }
            await SynchronizeAudioList(listToUpload.Count());
        }

        private async Task UploadFiles(List<AudioOperation> listToUpload)
        {
            int i = 1;
            foreach (var file in listToUpload)
            {
                labelOperation.Text = "Subiendo archivo: " + file.Name;
                labelActualNumber.Text = i.ToString();
                var result = await _services.AudioService.UploadAudio(file.PathFileUpload);
                _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
                i++;
                await Task.Delay(300);
            }
        }

        private async Task SynchronizeAudioList(int uploadCount)
        {
            labelOperation.Text = "Sincronizando archivos";
            if (uploadCount > 0)
            {
                labelActualNumber.Text = (Int32.Parse(labelActualNumber.Text) + 1).ToString();
            }
            var result = await _services.AudioService.SynchronizeAudioList(TransformAudioOperationListToTextFile());
            _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
            await Task.Delay(300);
        }

        private string TransformAudioOperationListToTextFile()
        {
            string result = string.Empty;
            foreach (var audioOperation in _audioOperationList)
            {
                result += audioOperation.Name + Environment.NewLine;
            }

            return result.TrimEnd('\r', '\n');
        }
    }
}
