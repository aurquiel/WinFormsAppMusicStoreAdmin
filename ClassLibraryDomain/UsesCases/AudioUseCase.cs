using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.UsesCases
{
    public class AudioUseCase : IAudioDriving
    {
        private readonly IAudioPersistencePort _audioPersistencePort;

        public AudioUseCase(IAudioPersistencePort audioPersistencePort)
        {
            _audioPersistencePort = audioPersistencePort;
        }

        public async Task<GeneralAnswer<List<AudioFile>>> DownloadListServerAsync(CancellationToken token)
        {
            return await _audioPersistencePort.DownloadAudioListServerAsync(token);
        }

        public async Task<GeneralAnswer<object>> DownloadAudioServerAsync(string storeCode, string audioName, string folderPath, CancellationToken token)
        {
            return await _audioPersistencePort.DownloadAudioServerAsync(storeCode, audioName, folderPath, token);
        }

        public async Task<GeneralAnswer<object>> UploadAudioAsync(string filePath, CancellationToken token)
        {
            return await _audioPersistencePort.UploadAudioAsync(filePath, token);
        }

        public async Task<GeneralAnswer<object>> AudioDeleteAsync(string audioName, CancellationToken token)
        {
            return await _audioPersistencePort.AudioDeleteAsync(audioName, token);
        }
    }
}
