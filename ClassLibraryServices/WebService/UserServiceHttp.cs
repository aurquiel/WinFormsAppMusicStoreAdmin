using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices.WebService
{
    internal class UserServiceHttp : IUserService
    {
        private WebServiceParams22 _webParams;

        public UserServiceHttp(WebServiceParams22 webParams)
        {
            _webParams = webParams;
        }

        public async Task<GeneralAnswerDto222<UserToken>> UserAccess(UserAccess22 userAccess)
        {
            var result = await UserAccessHttp.UserAccessPost(userAccess, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<UserToken>(result.Item3.status,result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<UserToken>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<List<User22>>> UserGetAll()
        {
            var result = await UserHttp.UserGetAll(_webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<User22>>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<User22>>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> UserCrete(User22 user)
        {
            var result = await UserHttp.UserPost(user, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> UserUpdate(User22 user)
        {
            var result = await UserHttp.UserPut(user, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> UserDelete(User22 user)
        {
            var result = await UserHttp.UserDelete(user, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object> (result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }
    }
}
