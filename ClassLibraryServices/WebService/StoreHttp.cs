using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClassLibraryServices.WebService
{
    internal class StoreHttp
    {
        internal static async Task<(bool, string, GeneralAnswerDto222<List<Store22>>)> StoreGetAll(WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);

                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);

                var response = await client.GetAsync(_params._IP_WEB_SERVICE + $"api/Store/StoreGetAll");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswerDto222<List<Store22>>>(result));
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
                    new GeneralAnswerDto222<List<Store22>>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> StorePost(Store22 store, WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(store);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_params._IP_WEB_SERVICE + $"api/Store/StoreInsert", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswerDto222<object>>(result));
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
                    new GeneralAnswerDto222<object>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> StorePut(Store22 store, WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(store);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(_params._IP_WEB_SERVICE + $"api/Store/StoreUpdate", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswerDto222<object>>(result));
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
                    new GeneralAnswerDto222<object>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> StoreDelete(Store22 store, WebServiceParams22 _params)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(_params._IP_WEB_SERVICE + $"api/Store/StoreDelete"),
                    Content = new StringContent(JsonSerializer.Serialize(store), Encoding.UTF8, "application/json")
                };

                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                var response = await client.SendAsync(request);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswerDto222<object>>(result));
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
                    new GeneralAnswerDto222<object>());
            }
        }
    }
}
