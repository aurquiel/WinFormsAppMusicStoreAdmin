using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IAudioListPersistencePort
    {
        Task<GeneralAnswer<List<AudioFile>>> DownloadAudioListStoreAsync(int storeId, CancellationToken token);
        Task<GeneralAnswer<object>> SynchronizeAudioListStoreAsync(List<AudioFile> audioList, int storeId, CancellationToken token);
        Task<GeneralAnswer<object>> SynchronizeAudioListAllStoreAsync(CancellationToken token);
    }
}
