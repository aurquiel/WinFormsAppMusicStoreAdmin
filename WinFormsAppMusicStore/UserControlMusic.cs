using ClassLibraryFiles;
using ClassLibraryModels;
using ClassLibraryServices;
using Serilog;
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
    public partial class UserControlMusic : UserControl
    {
        private IServices _services;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private IFileManager _fileManager;
        private BindingSource _bindingAudioListOperationList = new BindingSource();
        private BindingList<AudioOperation> _audioOperationList;

        public UserControlMusic(IServices services, EventHandler<(bool, string)> raiseRichTextInsertMessage, IFileManager fileManager)
        {
            InitializeComponent();
            _services = services;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _fileManager = fileManager;
            new Action(async () => await LoadAudioFromFile())();
        }

        private async Task LoadAudioFromFile()
        {
            var result = await _fileManager.GetAudioList();
            if (result.status)
            {
                _audioOperationList = new BindingList<AudioOperation>(result.data);
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
            if (itemIndex < listBoxAudio.Items.Count - 1)
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

    }
}
