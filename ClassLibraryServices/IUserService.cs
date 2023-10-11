using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices
{
    public interface IUserService
    {
        public Task<GeneralAnswerDto222<UserToken>> UserAccess(UserAccess22 userAccess);
        public Task<GeneralAnswerDto222<List<User22>>> UserGetAll();
        public Task<GeneralAnswerDto222<object>> UserCrete(User22 user);
        public Task<GeneralAnswerDto222<object>> UserUpdate(User22 user);
        public Task<GeneralAnswerDto222<object>> UserDelete(User22 user);
    }
}
