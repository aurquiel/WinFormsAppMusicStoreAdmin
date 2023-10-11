using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class StoreSynchronizeListAudio : Handler
    {
        private readonly IMapper _mapper;
        private IAudioListDriving _audioListDriving;
        private EventHandler<string> _updateLabelMessage;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationToken _token;
        private List<AudioFileSelect> _audioFileListToSynchronize;
        private int _storeId;

        public StoreSynchronizeListAudio(
            IMapper mapper,
            IAudioListDriving audioListDriving,
            EventHandler<string> updateLabelMessage,
            EventHandler<List<AudioFileSelect>> getAudioListFiles,
            EventHandler<(bool, string)> raiseRichTextInsertMessage,
            CancellationToken token,
            List<AudioFileSelect> audioFileListToSynchronize,
            int storeId)
        {
            _mapper = mapper;
            _audioListDriving = audioListDriving;
            _updateLabelMessage = updateLabelMessage;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _token = token;
            _audioFileListToSynchronize = audioFileListToSynchronize;
            _storeId = storeId;
        }

        public override async Task HandleRequest(OperationTypes.OPERATIONS operation)
        {
            if (operation == OperationTypes.OPERATIONS.STORE_SYNCHRONIZE_LIST_AUDIO)
            {
                _updateLabelMessage?.Invoke(this, $"Subiendo y sincronizando lista de audio de tienda: {_storeId}");
                var result = await _audioListDriving.SynchronizeAudioListStore(_mapper.Map<List<AudioFileSelect>, List<AudioFile>>(_audioFileListToSynchronize), _storeId, _token);
                _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
                if (_token.IsCancellationRequested)
                {
                    _raiseRichTextInsertMessage?.Invoke(this, (false, "Operacion Cancelada."));
                    return;
                }
            }
            else if (successor != null)
            {
                await successor.HandleRequest(operation);
            }
        }
    }
}
