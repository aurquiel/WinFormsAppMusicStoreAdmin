using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters
{
    public class UserPersistenceAdapter : IUserPersistencePort
    {
        private readonly IMapper _mapper;

        public UserPersistenceAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GeneralAnswer<List<User>>> GetAllAsync()
        {
            var result = await UserGetAll();

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<List<User>>(result.Item3.status, result.Item3.statusMessage, _mapper.Map<List<UserDto>, List<User>>(result.Item3.data));
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<List<User>>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<List<UserDto>>)> UserGetAll()
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                var response = await client.GetAsync(WebServiceParams.IP_WEB_SERVICE + $"api/User/UserGetAll");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswer<List<UserDto>>>(result));
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
                    new GeneralAnswer<List<UserDto>>());
            }
        }

        public async Task<GeneralAnswer<object>> InsertAsync(User user)
        {
            var result = await UserPost(user);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> UserPost(User user)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(WebServiceParams.IP_WEB_SERVICE + $"api/User/UserInsert", data);

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
                        "Error al crear Usuario en el servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al crear Usuario en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }

        public async Task<GeneralAnswer<object>> UpdateAsync(User user)
        {
            var result = await UserPut(user);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> UserPut(User user)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PutAsync(WebServiceParams.IP_WEB_SERVICE + $"api/User/UserUpdate", data);

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
                    "Error al actualizar Usuario en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }

        public async Task<GeneralAnswer<object>> DeleteAsync(int userId)
        {
            var result = await UserDelete(userId);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> UserDelete(int userId)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(WebServiceParams.IP_WEB_SERVICE + $"api/User/UserDelete/{userId}"),
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
                    "Error al eliminar Usuario en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }
    }
}
