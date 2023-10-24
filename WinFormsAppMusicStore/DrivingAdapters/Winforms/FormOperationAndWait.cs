﻿using AutoMapper;
using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin
{
    public partial class FormOperationAndWait : Form
    {
        private List<Operation> _operations;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private CancellationToken _token;

        public List<AudioFileSelect> AudioFileListDownloaded { get; set; } = new List<AudioFileSelect>();
        public List<Operation> Operations { set => _operations = value; }

        private Handler h1;
        private Handler h2;
        private Handler h3;
        private Handler h4;
        private Handler h5;
        private Handler h6;
        private Handler h7;
        private Handler h8;

        private EventHandler<string> _updateLabelMessage;
        private EventHandler<List<AudioFileSelect>> _getAudioListFiles;

        private readonly IMapper _mapper;
        private readonly IAudioDriving _audioDriving;
        private readonly IAudioListDriving _audioListDriving;
        private readonly IFileManagerDriving _fileManagerDriving;
        private readonly IAudioListLocalDriving _audioListLocalDriving;

        public FormOperationAndWait(IMapper mapper, IAudioDriving audioDriving, IAudioListDriving audioListDriving,
            IFileManagerDriving fileManagerDriving, IAudioListLocalDriving audioListLocalDriving)
        {
            _token = _tokenSource.Token;
            WireUpEvents();
            InitializeComponent();
            _mapper = mapper;
            _audioDriving = audioDriving;
            _audioListDriving = audioListDriving;
            _fileManagerDriving = fileManagerDriving;
            _audioListLocalDriving = audioListLocalDriving;
            this.StartPosition = FormStartPosition.CenterParent;
        }

        public void SuscribeRichTextEvent(EventHandler<(bool, string)> raiseRichTextInsertMessage)
        {
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
        }

        //Patron de diseño de responsabilidad
        private void InitChainOfResponsibility(Operation operation)
        {
            h1 = new ServerGetAudioListHandler(
                _mapper,
                _audioDriving,
                _updateLabelMessage,
                _getAudioListFiles,
                _raiseRichTextInsertMessage,
                _token);

            h2 = new ServerUploadAudioHandler(
                _audioDriving,
                _updateLabelMessage,
                _raiseRichTextInsertMessage,
                _token,
                operation.AudioFileToOperate
                );

            h3 = new ServerDeleteAudioHandler(
                _audioDriving,
                _updateLabelMessage,
                _raiseRichTextInsertMessage,
                _token,
                operation.AudioFileToOperate
                );

            h4 = new StoreSynchronizeAllStoreHandler(
                _audioListDriving,
                _updateLabelMessage,
                _getAudioListFiles,
                _raiseRichTextInsertMessage,
                _token
                );

            h5 = new StoreGetAudioListHandler(
                _mapper,
                _audioListDriving,
                _updateLabelMessage,
                _getAudioListFiles,
                _raiseRichTextInsertMessage,
                _token,
                operation.Store
                );

            h6 = new StoreSynchronizeListAudio(
                _mapper,
                _audioListDriving,
                _updateLabelMessage,
                _getAudioListFiles,
                _raiseRichTextInsertMessage,
                _token,
                operation.AudioFileToOperate,
                operation.Store
                );

            h7 = new PlayerGetAudioListStorePcHandler(
                _mapper,
                _audioListLocalDriving,
                _updateLabelMessage,
                _getAudioListFiles,
                _raiseRichTextInsertMessage,
                _token,
                operation.Store
                );

            h8 = new PlayerGetAudioListStoreServerHandler(
                _audioDriving,
                _audioListDriving,
                _audioListLocalDriving,
                _fileManagerDriving,
                _updateLabelMessage,
                _getAudioListFiles,
                _raiseRichTextInsertMessage,
                _token,
                operation.Store
                );

            h1.SetSuccessor(h2);
            h2.SetSuccessor(h3);
            h3.SetSuccessor(h4);
            h4.SetSuccessor(h5);
            h5.SetSuccessor(h6);
            h6.SetSuccessor(h7);
            h7.SetSuccessor(h8);
        }

        private void WireUpEvents()
        {
            _updateLabelMessage += UpdateLabelMessage;
            _getAudioListFiles += GetAudioListFiles;
        }

        private void UpdateLabelMessage(object sender, string e)
        {
            labelMessage.Text = e;
        }

        private void GetAudioListFiles(object sender, List<AudioFileSelect> e)
        {
            AudioFileListDownloaded = e;
        }

        private void FormOperationAndWait_FormClosing(object sender, FormClosingEventArgs e)
        {
            _tokenSource.Cancel();
            this.Hide();
            e.Cancel = true;
        }

        private async void FormWait_Shown(object sender, EventArgs e)
        {
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            await Task.Delay(500);
            await DoOperations(_token);
            this.Hide();
        }

        private async Task DoOperations(CancellationToken token)
        {
            foreach (var operation in _operations)
            {
                InitChainOfResponsibility(operation);
                if (token.IsCancellationRequested)
                {
                    return;
                }
                await h1.HandleRequest(operation.TypeOfOperation);
            }
        }
    }
}
