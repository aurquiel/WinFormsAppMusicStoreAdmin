using AutoMapper;
using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters
{
    public class RegisterPersistenceAdapter : IRegisterPersistencePort
    {
        private readonly IMapper _mapper;

        public RegisterPersistenceAdapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<GeneralAnswer<List<Register>>> GetByIdAndMonthAsync(int storeId, DateTime date)
        {
            var result = await RegistersGetByMonth(storeId, date);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<List<Register>>(result.Item3.status, result.Item3.statusMessage, _mapper.Map<List<RegisterDto>, List<Register>>(result.Item3.data));
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<List<Register>>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<List<RegisterDto>>)> RegistersGetByMonth(int storeId, DateTime date)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                var response = await client.GetAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Register/GetRegistersByMonth/{storeId}/{date.ToString("dd-MM-yyyy")}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswer<List<RegisterDto>>>(result));
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
                    new GeneralAnswer<List<RegisterDto>>());
            }
        }

        public async Task<GeneralAnswer<List<Register>>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            var result = await RegisterGetByRangeDate(storeId, dateInit, dateEnd);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<List<Register>>(result.Item3.status, result.Item3.statusMessage, _mapper.Map<List<RegisterDto>, List<Register>>(result.Item3.data));
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<List<Register>>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<List<RegisterDto>>)> RegisterGetByRangeDate(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;

                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                var response = await client.GetAsync(WebServiceParams.IP_WEB_SERVICE + $"api/Register/GetRegisters/{storeId}/{dateInit.ToString("dd-MM-yyyy")}/{dateEnd.ToString("dd-MM-yyyy")}");

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var result = await response.Content.ReadAsStringAsync();

                    return (
                    true,
                    "Respuesta del servidor obtenida con exito.",
                    JsonSerializer.Deserialize<GeneralAnswer<List<RegisterDto>>>(result));
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
                    new GeneralAnswer<List<RegisterDto>>());
            }
        }

        public async Task<GeneralAnswer<object>> InsertAsync(List<Register> registers)
        {
            var result = await RegisterPost(registers);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> RegisterPost(List<Register> registers)
        {
            try
            {
                HttpClientHandler handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback = Certificate.ValidateServerCertificate;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(WebServiceParams.TIMEOUT_WEB_SERVICE);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", WebServiceParams.TOKEN_WEB_SERVICE);
                string json = JsonSerializer.Serialize(registers);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(WebServiceParams.IP_WEB_SERVICE + "api/Register/RegisterInsert/", data);

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
                        "Error al crear registro en el servidor. Estatus: " + response.StatusCode,
                        null);
                }

            }
            catch (Exception ex)
            {
                return (
                false,
                    "Error al crear registro en el servidor., Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }

        public async Task<GeneralAnswer<object>> DeleteAllByStoreIdAsync(int storeId)
        {
            var result = await RegisterDelete(storeId);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object>(result.Item1, result.Item2, null);
            }
        }

        private async Task<(bool, string, GeneralAnswer<object>)> RegisterDelete(int storeId)
        {
            try
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Delete,
                    RequestUri = new Uri(WebServiceParams.IP_WEB_SERVICE + $"api/Register/RegisterDelete/{storeId}"),
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
                        "Error al eliminar Registros en el servidor. Estatus: " + response.StatusCode,
                        null);
                }
            }
            catch (Exception ex)
            {
                return (
                    false,
                    "Error al eliminar Registros en el servidor, Excepcion: " + ex.Message,
                    new GeneralAnswer<object>());
            }
        }
    }
}
