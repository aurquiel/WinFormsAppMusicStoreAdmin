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
        public Task<GeneralAnswer<string>> DownloadAudioList();
        public Task<GeneralAnswer<string>> DownloadAudioListStore(string storeCode);
        public Task<GeneralAnswer<object>> SynchronizeAudioList(string audioList, string storeCode);
        public Task<GeneralAnswer<object>> UploadAudio(string filePath);
        public Task<GeneralAnswer<object>> DownloadAudio(string audioName);
        public Task<GeneralAnswer<object>> DeleteAudios(List<string> audioNamesList);
    }
}
