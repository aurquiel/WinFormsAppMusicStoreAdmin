using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driving;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class PlayerGetAudioListStoreServerHandler : Handler
    {
        private readonly IAudioDriving _audioDriving;
        private readonly IAudioListDriving _audioListDriving;
        private readonly IAudioListLocalDriving _audioListLocalDriving;
        private readonly IFileManagerDriving _fileManagerDriving;
        private EventHandler<string> _updateLabelMessage;
        private EventHandler<List<AudioFileSelect>> _getAudioListFiles;
        private EventHandler<(bool, string)> _raiseRichTextInsertMessage;
        private CancellationToken _token;
        private Store _store;

        public PlayerGetAudioListStoreServerHandler(
            IAudioDriving audioDriving,
            IAudioListDriving audioListDriving,
            IAudioListLocalDriving audioListLocalDriving,
            IFileManagerDriving fileManagerDriving,
            EventHandler<string> updateLabelMessage,
            EventHandler<List<AudioFileSelect>> getAudioListFiles,
            EventHandler<(bool, string)> raiseRichTextInsertMessage,
            CancellationToken token,
            Store store)
        {
            _audioDriving = audioDriving;
            _audioListDriving = audioListDriving;
            _audioListLocalDriving = audioListLocalDriving;
            _fileManagerDriving = fileManagerDriving;
            _updateLabelMessage = updateLabelMessage;
            _getAudioListFiles = getAudioListFiles;
            _raiseRichTextInsertMessage = raiseRichTextInsertMessage;
            _token = token;
            _store = store;
        }

        public override async Task HandleRequest(OperationTypes.OPERATIONS operation)
        {
            if (operation == OperationTypes.OPERATIONS.PLAYER_GET_AUDIO_LIST_STORE_SERVER)
            {
                _updateLabelMessage?.Invoke(this, "Espere obteniendo lista de audio de la tienda.");
                await Task.Delay(100);
                var result = await _audioListDriving.DownloadAudioListStoreAsync(_store.Id, _token);
                _raiseRichTextInsertMessage?.Invoke(this, (result.status, result.statusMessage));
                if (result.status)
                {
                    if (result.data.Count() == 0)
                    {
                        _getAudioListFiles?.Invoke(this, new List<AudioFileSelect>());
                    }
                    else
                    {
                        await _audioListLocalDriving.DeleteAudioListAsync(_store.Id);
                        result.data.ForEach(x => x.Path = $"{_fileManagerDriving.GetAudioStoreAdminPath()}\\{_store.Code}\\audio\\{x.Name}");
                        await _audioListLocalDriving.CreateAudioListAsync(result.data);

                        var listToDowmload = _fileManagerDriving.GetAudioListToDownload(result.data.Select(x => x.Name).ToList(), _store.Code);
                        if (listToDowmload.Count() > 0)
                        {
                            foreach (var audio in listToDowmload)
                            {
                                await Task.Delay(300);
                                _updateLabelMessage?.Invoke(this, $"Descargando audio: {audio}.");
                                var resultDownload = await _audioDriving.DownloadAudioServerAsync(_store.Code, audio, _token);
                                _raiseRichTextInsertMessage?.Invoke(this, (resultDownload.status, resultDownload.statusMessage));
                                if (_token.IsCancellationRequested)
                                {
                                    return;
                                }
                            }
                        }

                        _updateLabelMessage?.Invoke(this, "Eliminando audios innecesarios.");
                        await Task.Delay(100);
                        _fileManagerDriving.EraseAudiosNotInAudioList(result.data.Select(x => x.Name).ToList(), _store.Code);

                        _getAudioListFiles?.Invoke(this, result.data.Select(x => new
                        AudioFileSelect
                        {
                            Select = false,
                            Id = x.Id,
                            Order = x.Order,
                            Name = x.Name,
                            StoreId = x.StoreId,
                            Duration = x.Duration,
                            Size = x.Size,
                            Path = $"{_fileManagerDriving.GetAudioStoreAdminPath()}\\{_store.Code}\\audio\\{x.Name}",
                            CheckForTime = x.CheckForTime,
                            TimeToPlay = x.TimeToPlay
                        }).ToList());
                    }
                }
                else if (successor != null)
                {
                    await successor.HandleRequest(operation);
                }
            }
        }
    }
}
