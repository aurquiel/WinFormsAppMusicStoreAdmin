using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class ServerDeleteAudioHandler : Handler
    {
        private IAudioDriving _audioDriving;
        private EventHandler<string> _updateLabelMessage;
        private EventHandler<List<AudioFileSelect>> _getAudioListFiles;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationToken _token;
        private List<AudioFileSelect> _audioFileListToDelete;

        public ServerDeleteAudioHandler(
            IAudioDriving audioDriving,
            EventHandler<string> updateLabelMessage,
            EventHandler<(bool, string)> raiseRichTextInsertMessage,
            CancellationToken token,
            List<AudioFileSelect> audioFileListToDelete)
        {
            _audioDriving = audioDriving;
            _updateLabelMessage = updateLabelMessage;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _token = token;
            _audioFileListToDelete = audioFileListToDelete;
        }

        public override async Task HandleRequest(OperationTypes.OPERATIONS operation)
        {
            if (operation == OperationTypes.OPERATIONS.SERVER_DELETE_AUDIO)
            {
                _updateLabelMessage?.Invoke(this, "Eliminando audios del servidor");
                await Task.Delay(100);
                foreach (var file in _audioFileListToDelete)
                {
                    _updateLabelMessage?.Invoke(this, "Eliminando audio: " + file.Name);
                    var result = await _audioDriving.AudioDeleteAsync(file.Name, _token);
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
