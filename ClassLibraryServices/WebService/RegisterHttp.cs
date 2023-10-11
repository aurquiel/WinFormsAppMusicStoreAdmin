using ClassLibraryModels;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace ClassLibraryServices.WebService
{
    internal class RegisterHttp
    {
        internal static async Task<(bool, string, GeneralAnswerDto222<List<Register22>>)> RegisterGetByMonth(WebServiceParams22 _params, int storeId, DateTime date)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                var response = await client.GetAsync(_params._IP_WEB_SERVICE + $"api/Register/GetRegistersByMonth/{storeId}/{date.ToString("dd-MM-yyyy")}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswerDto222<List<Register22>>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al obtener Registros del servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al obtener Registros del servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<List<Register22>>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<List<Register22>>)> RegisterGet(WebServiceParams22 _params, int storeId, DateTime dateInit, DateTime dateEnd)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                var response = await client.GetAsync(_params._IP_WEB_SERVICE + $"api/Register/GetRegisters/{storeId}/{dateInit.ToString("dd-MM-yyyy")}/{dateEnd.ToString("dd-MM-yyyy")}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswerDto222<List<Register22>>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al obtener Registros del servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al obtener Registros del servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<List<Register22>>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> RegisterDelete(WebServiceParams22 _params, int storeId)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(_params._IP_WEB_SERVICE + $"api/Register/RegisterDelete/{storeId}"),
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
                        "Error al eliminar Registros en el servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al eliminar Registros en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<object>());
            }
        }

        internal static async Task<(bool, string, GeneralAnswerDto222<object>)> RegisterPost(WebServiceParams22 _params, Register22 register)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _params._TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(register);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_params._IP_WEB_SERVICE + "api/Register/RegisterInsert/", data);

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
                        "Error al crear registro en el servidor. Estatus: " + response.StatusCode,
                        null);
                }

            }
            catch (Exception ex)
            {
                return (
                false,
                    "Error al crear registro en el servidor., Excepcion: " + ex.Message,
                    null);
            }
        }
    }
}
