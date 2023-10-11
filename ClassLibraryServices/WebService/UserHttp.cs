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
    internal static class UserHttp
    {
        internal static async Task<(bool, string, GeneralAnswerDto222<List<User22>>)> UserGetAll(WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                var response = await client.GetAsync(_params._IP_WEB_SERVICE + $"api/User/UserGetAll");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswerDto222<List<User22>>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al obtener Usuarios del servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al obtener Usuarios del servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<List<User22>>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> UserPost(User22 user, WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_params._IP_WEB_SERVICE + $"api/User/UserInsert", data);

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
                        "Error al crear Usuario en el servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al crear Usuario en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<object>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> UserPut(User22 user, WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(_params._IP_WEB_SERVICE + $"api/User/UserUpdate", data);

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
                    "Error al actualizar Usuario en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<object>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> UserDelete(User22 user, WebServiceParams22 _params)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(_params._IP_WEB_SERVICE + $"api/User/UserDelete"),
                    Content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json")
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
                    "Error al eliminar Usuario en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<object>());
            }
        }
    }
}
