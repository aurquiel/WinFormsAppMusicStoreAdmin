using ClassLibraryFiles;
using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices.WebService
{
    internal class AudioServiceHttp : IAudioService
    {
        private WebServiceParams _webParams;
        private IFileManager _fileManager;

        public AudioServiceHttp(WebServiceParams webParams, IFileManager fileManager)
        {
            _webParams = webParams;
            _fileManager = fileManager;
        }

        public async Task<GeneralAnswer<string>> DownloadAudioList()
        {
            var result = await AudioHttp.AduioGetAudioList(_webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<string> { status = result.Item3.status, statusMessage = result.Item3.statusMessage, data = result.Item3.data };
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<string> { status = result.Item1, statusMessage = result.Item2, data = null };
            }
        }

        public async Task<GeneralAnswer<object>> SynchronizeAudioList(string plainText)
        {
            var result = await AudioHttp.SynchronizeAudioList(_webParams, plainText);

            return new GeneralAnswer<object> { status = result.Item1, statusMessage = result.Item2, data = null };
        }

        public async Task<GeneralAnswer<object>> UploadAudio(string pathFile)
        {
            var result = await AudioHttp.UploadAudio(_webParams, pathFile);

            return new GeneralAnswer<object> { status = result.Item1, statusMessage = result.Item2, data = null };
        }
    }
}
