using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters
{
    public class AudioPersistenceAdapter : IAudioPersistencePort
    {
        private readonly IMapper _mapper;
        private readonly IFileManagerPersistencePort _fileManagerPersistencePort;

        public AudioPersistenceAdapter(IMapper mapper, IFileManagerPersistencePort fileManagerPersistencePort)
        {
            _mapper = mapper;
            _fileManagerPersistencePort = fileManagerPersistencePort;
        }

        public async Task<GeneralAnswer<List<AudioFile>>> DownloadAudioListServerAsync(CancellationToken token)
        {
            var result = await GetAudioListFromServer(token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<List<AudioFile>>(result.Item3.status, result.Item3.statusMessage, _mapper.Map<List<AudioFileDto>, List<AudioFile>>(result.Item3.data));
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<List<AudioFile>>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<List<AudioFileDto>>)> GetAudioListFromServer(CancellationToken token)
        {
            try
            {

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var httpClient = new HttpClient(handler);
                httpClient.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);

                var response = await httpClient.GetAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Audio/DownloadAudioListServer", token);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Archivo lista de audio obtenido del servidor.",
                        JsonSerializer.Deserialize<GeneralAnswer<List<AudioFileDto>>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al obtener archivo lista de audio. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al obtener archivo lista de audio, Excepcion: " + ex.Message,
                    null);
            }
        }

        public async Task<GeneralAnswer<object>> DownloadAudioServerAsync(string storeCode, string audioName, string folderPath, CancellationToken token)
        {
            var result = await DownloadAudio(storeCode, audioName, token);

            return new GeneralAnswer<object>(result.Item1, result.Item2, null);
        }

        private async Task<(bool, string, object)> DownloadAudio(string storeCode, string audioName, CancellationToken token)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);

                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE_HEAVY_TASK);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);

                var response = await client.GetAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Audio/DownloadAudio/" + audioName, token);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    Stream streamToReadFrom = await response.Content.ReadAsStreamAsync();
                    var path = _fileManagerPersistencePort.GetAudioStoreAdminPath() + $"\\{storeCode}\\audio\\{audioName}";
                    using (var fs = new FileStream(path, FileMode.Create))
                    {
                        await response.Content.CopyToAsync(fs);
                    }

                    return (
                        true,
                        "Archivo de audio obtenido del servidor.",
                        null);
                }
                else
                {
                    return (
                        false,
                        "Error al obtener archivo de audio del servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al obtener archivo de audio del servidor. Excepcion: " + ex.Message,
                    null);
            }
        }

        public async Task<GeneralAnswer<object>> UploadAudioAsync(string filePath, CancellationToken token)
        {
            var result = await UploadAudio(filePath, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> UploadAudio(string filePath, CancellationToken token)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE_HEAVY_TASK);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);

                var form = new MultipartFormDataContent();

                byte[] fileData = File.ReadAllBytes(filePath);

                ByteArrayContent byteContent = new ByteArrayContent(fileData);

                byteContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");

                form.Add(byteContent, "file", Path.GetFileName(filePath));

                var response = await client.PostAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Audio/UploadAudio", form, token);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Audio subido con exito al servidor servidor.",
                        JsonSerializer.Deserialize<GeneralAnswer<object>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al subir audio al servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al subir audio al servidor, Excepcion: " + ex.Message,
                    null);
            }
        }

        public async Task<GeneralAnswer<object>> AudioDeleteAsync(string audioName, CancellationToken token)
        {
            var result = await DeleteAudio(audioName, token);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<string>)> DeleteAudio(string audioName, CancellationToken token)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(WebServiceParams.IP_WEB_SERVICE + $"api/Audio/DeleteAudio"),
                    Content = new StringContent(JsonSerializer.Serialize(audioName), Encoding.UTF8, "application/json")
                };

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                var response = await client.SendAsync(request, token);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Archivo de audio eliminado del servisor.",
                        JsonSerializer.Deserialize<GeneralAnswer<string>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al eliminar archivo de audio del servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al eliminar archivo de audio del servidor, Excepcion: " + ex.Message,
                    null);
            }
        }
    }
}
