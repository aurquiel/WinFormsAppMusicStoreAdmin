using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices.WebService
{
    public class WebService : IServices
    {
        public IUserService UserService { get; set; }

        private WebServiceParams _webParams;

        public WebService(string IP_WEB_SERVICE, int TIMEOUT_WEB_SERVICE)
        {
            _webParams = new WebServiceParams(IP_WEB_SERVICE, TIMEOUT_WEB_SERVICE);
            UserService = new UserServiceHttp(_webParams);
        }

        public void SetToken(string token)
        {
            _webParams.SetToken(token);
            UserService = new UserServiceHttp(_webParams);
        }
    }
}
