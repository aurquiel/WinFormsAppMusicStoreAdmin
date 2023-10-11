using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters
{
    public class StorePersistenceAdapter : IStorePersistencePort
    {
        private readonly IMapper _mapper;

        public StorePersistenceAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GeneralAnswer<List<Store>>> GetAllAsync()
        {
            var result = await StoreGetAll();

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<List<Store>>(result.Item3.status, result.Item3.statusMessage, _mapper.Map<List<StoreDto>, List<Store>>(result.Item3.data));
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<List<Store>>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<List<StoreDto>>)> StoreGetAll()
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);

                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);

                var response = await client.GetAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Store/StoreGetAll");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswer<List<StoreDto>>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al obtener Tiendas del servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error, Excepcion: " + ex.Message,
                    new GeneralAnswer<List<StoreDto>>());
            }
        }

        public async Task<GeneralAnswer<object>> InsertAsync(Store store)
        {
            var result = await StorePost(store);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> StorePost(Store store)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(store);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Store/StoreInsert", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswer<object>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al crear Usuario en el servidor.  Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error UserPost, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }

        public async Task<GeneralAnswer<object>> UpdateAsync(Store store)
        {
            var result = await StorePut(store);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> StorePut(Store store)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(store);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Store/StoreUpdate", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswer<object>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al actualizar Usuario en el servidor. Estatus: " + response.StatusCode,
                        null);
                }

            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error UserPut, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }

        public async Task<GeneralAnswer<object>> DeleteAsync(int storeId)
        {
            var result = await StoreDelete(storeId);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> StoreDelete(int storeId)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(WebServiceParams.IP_WEB_SERVICE + $"api/Store/StoreDelete/{storeId}"),
                };

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswer<object>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al eliminar Usuario en el servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error UserDelete, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }
    }
}
