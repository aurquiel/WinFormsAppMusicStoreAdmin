using ClassLibraryDomain.Models;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IAudioPersistencePort
    {
        Task<GeneralAnswer<List<AudioFile>>> DownloadAudioListServerAsync(CancellationToken token);
        Task<GeneralAnswer<object>> UploadAudioAsync(string filePath, CancellationToken token);
        Task<GeneralAnswer<object>> DownloadAudioServerAsync(string storeCode, string audioName, CancellationToken token);
        Task<GeneralAnswer<object>> AudioDeleteAsync(string audioName, CancellationToken token);
    }
}
