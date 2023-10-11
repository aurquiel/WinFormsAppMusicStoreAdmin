using ClassLibraryModels;
using System.Text;
using System.Text.Json;

namespace ClassLibraryServices.WebService
{
    internal class UserAccessHttp
    {
        internal static async Task<(bool, string, GeneralAnswerDto222<UserToken>)> UserAccessPost(UserAccess22 userAccess, WebServiceParams22 _params)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(_params._TIMEOUT_WEB_SERVICE);
                string json = JsonSerializer.Serialize(userAccess);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(_params._IP_WEB_SERVICE + "api/Access/", data);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                        true,
                        "Respuesta del servidor obtenida con exito.",
                        JsonSerializer.Deserialize<GeneralAnswerDto222<UserToken>>(result));
                }
                else
                {
                    return (
                        false,
                        "Error al obtener credenciales. Estatus: " + response.StatusCode,
                        null);
                }

            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error UserAccessPost, Excepcion: " + ex.Message,
                    new GeneralAnswerDto222<UserToken>());
            }
        }
    }
}
