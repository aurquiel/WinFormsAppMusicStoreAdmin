using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices
{
    public interface IAudioService
    {
        public Task<GeneralAnswerDto222<List<AudioFile>>> DownloadAudioListServerAsync(CancellationToken token);
        public Task<GeneralAnswerDto222<List<AudioFile>>> DownloadAudioListStoreAsync(string storeCode, CancellationToken token);
        public Task<GeneralAnswerDto222<object>> SynchronizeAudioListStore(List<AudioFile> audioList, string storeCode, CancellationToken token);
        public Task<GeneralAnswerDto222<object>> SynchronizeAudioListAllStoreAsync(CancellationToken token);
        public Task<GeneralAnswerDto222<object>> UploadAudioServerAsync(string filePath, CancellationToken token);
        public Task<GeneralAnswerDto222<object>> DownloadAudioServer(string storeCode, string audioName, CancellationToken token);
        public Task<GeneralAnswerDto222<object>> DeleteAudioServerAsync(string audioName, CancellationToken token);
    }
}
