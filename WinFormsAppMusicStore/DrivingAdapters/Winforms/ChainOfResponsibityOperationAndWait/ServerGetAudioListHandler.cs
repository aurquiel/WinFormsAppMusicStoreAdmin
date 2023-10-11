using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class ServerGetAudioListHandler : Handler
    {
        private readonly IMapper _mapper;
        private readonly IAudioDriving _audioDriving;
        private EventHandler<string> _updateLabelMessage;
        private EventHandler<List<AudioFileSelect>> _getAudioListFiles;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationToken _token;

        public ServerGetAudioListHandler(
            IMapper mapper,
            IAudioDriving services,
            EventHandler<string> updateLabelMessage,
            EventHandler<List<AudioFileSelect>> getAudioListFiles,
            EventHandler<(bool, string)> raiseRichTextInsertMessage,
            CancellationToken token)
        {
            _mapper = mapper;
            _audioDriving = services;
            _updateLabelMessage = updateLabelMessage;
            _getAudioListFiles = getAudioListFiles;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _token = token;
        }

        public override async Task HandleRequest(OperationTypes.OPERATIONS operation)
        {
            if (operation == OperationTypes.OPERATIONS.SERVER_GET_AUDIO_LIST)
            {
                _updateLabelMessage?.Invoke(this, "Espere obteniendo lista de audios del servidor.");
                await Task.Delay(100);
                var result = await _audioDriving.DownloadListServerAsync(_token);
                _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
                if (result.status)
                {
                    _getAudioListFiles?.Invoke(this, _mapper.Map<List<AudioFile>, List<AudioFileSelect>>(result.data));
                }
            }
            else if (successor != null)
            {
                await successor.HandleRequest(operation);
            }
        }
    }
}
