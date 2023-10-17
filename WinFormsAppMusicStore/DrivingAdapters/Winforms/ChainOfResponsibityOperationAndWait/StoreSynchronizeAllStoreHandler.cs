using ClassLibraryDomain.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class StoreSynchronizeAllStoreHandler : Handler
    {
        private IAudioListDriving _audioListDriving;
        private EventHandler<string> _updateLabelMessage;
        private EventHandler<List<AudioFileSelect>> _getAudioListFiles;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationToken _token;

        public StoreSynchronizeAllStoreHandler(
            IAudioListDriving audioListDriving,
            EventHandler<string> updateLabelMessage,
            EventHandler<List<AudioFileSelect>> getAudioListFiles,
            EventHandler<(bool, string)> raiseRichTextInsertMessage,
            CancellationToken token)
        {
            _audioListDriving = audioListDriving;
            _updateLabelMessage = updateLabelMessage;
            _getAudioListFiles = getAudioListFiles;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _token = token;
        }

        public override async Task HandleRequest(OperationTypes.OPERATIONS operation)
        {
            if (operation == OperationTypes.OPERATIONS.SERVER_SYNCHRONIZE_STORES)
            {
                _updateLabelMessage?.Invoke(this, "Sincronizando tiendas");
                await Task.Delay(100);
                var result = await _audioListDriving.SynchronizeAudioListAllStoreAsync(_token);
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
