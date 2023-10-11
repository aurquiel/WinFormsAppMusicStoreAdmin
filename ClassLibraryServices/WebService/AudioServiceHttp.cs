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
        private WebServiceParams22 _webParams;
        private IFileManager _fileManager;

        public AudioServiceHttp(WebServiceParams22 webParams, IFileManager fileManager)
        {
            _webParams = webParams;
            _fileManager = fileManager;
        }

        public async Task<GeneralAnswerDto222<List<AudioFile>>> DownloadAudioListServerAsync(CancellationToken token)
        {
            var result = await AudioHttp.GetAudioList(_webParams, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<AudioFile>>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<AudioFile>>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<List<AudioFile>>> DownloadAudioListStoreAsync(string storeCode, CancellationToken token)
        {
            var result = await AudioHttp.GetAudioListStore(_webParams, storeCode, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<AudioFile>>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<AudioFile>>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> SynchronizeAudioListStore(List<AudioFile> audioList, string storeCode, CancellationToken token)
        {
            var result = await AudioHttp.SynchronizeAudioListStore(_webParams, audioList, storeCode, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> UploadAudioServerAsync(string pathFile, CancellationToken token)
        {
            var result = await AudioHttp.UploadAudio(_webParams, pathFile, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> DownloadAudioServer(string storeCode, string audioName, CancellationToken token)
        {
            var result = await AudioHttp.DownloadAudio(_webParams, storeCode, audioName, _fileManager, token);

            return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
        }

        public async Task<GeneralAnswerDto222<object>> DeleteAudioServerAsync(string audioName, CancellationToken token)
        {
            var result = await AudioHttp.DeleteAudio(_webParams, audioName, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> SynchronizeAudioListAllStoreAsync(CancellationToken token)
        {
            var result = await AudioHttp.SynchronizeAudioListAllStore(_webParams, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }
    }
}
