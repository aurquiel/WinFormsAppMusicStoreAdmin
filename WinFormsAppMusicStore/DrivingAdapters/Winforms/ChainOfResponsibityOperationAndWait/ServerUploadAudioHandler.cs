using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class ServerUploadAudioHandler : Handler
    {
        private IAudioDriving _audioDriving;
        private EventHandler<string> _updateLabelMessage;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationToken _token;
        private List<AudioFileSelect> _audioFileListToUpload;

        public ServerUploadAudioHandler(
            IAudioDriving audioDriving,
            EventHandler<string> updateLabelMessage,
            EventHandler<(bool, string)> raiseRichTextInsertMessage,
            CancellationToken token,
            List<AudioFileSelect> audioFileListToUpload)
        {
            _audioDriving = audioDriving;
            _updateLabelMessage = updateLabelMessage;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _token = token;
            _audioFileListToUpload = audioFileListToUpload;
        }

        public override async Task HandleRequest(OperationTypes.OPERATIONS operation)
        {
            if (operation == OperationTypes.OPERATIONS.SERVER_UPLOAD_AUDIO)
            {
                _updateLabelMessage?.Invoke(this, "Subiendo audio al servidor");
                await Task.Delay(100);
                foreach (var file in _audioFileListToUpload)
                {
                    _updateLabelMessage?.Invoke(this, "Subiendo audio: " + file.Name);
                    var result = await _audioDriving.UploadAudioAsync(file.Path, _token);
                    _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
                    if (_token.IsCancellationRequested)
                    {
                        _raiseRichTextInsertMessage?.Invoke(this, (false, "Operacion Cancelada."));
                        return;
                    }
                }
            }
            else if (successor != null)
            {
                await successor.HandleRequest(operation);
            }
        }
    }
}
