using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IAudioDriving
    {
        Task<GeneralAnswer<List<AudioFile>>> DownloadListServerAsync(CancellationToken token);
        Task<GeneralAnswer<object>> UploadAudioAsync(string filePath, CancellationToken token);
        Task<GeneralAnswer<object>> DownloadAudioServerAsync(string storeCode, string audioName, CancellationToken token);
        Task<GeneralAnswer<object>> AudioDeleteAsync(string audioName, CancellationToken token);
    }
}
