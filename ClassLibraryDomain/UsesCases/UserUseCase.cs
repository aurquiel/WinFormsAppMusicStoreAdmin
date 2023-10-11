using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.UsesCases
{
    public class UserUseCase : IUserDriving
    {
        private readonly IUserPersistencePort _userPersistencePort;

        public UserUseCase(IUserPersistencePort userPersistencePort)
        {
            _userPersistencePort = userPersistencePort;
        }

        public async Task<GeneralAnswer<List<User>>> GetAllAsync()
        {
            return await _userPersistencePort.GetAllAsync();
        }

        public async Task<GeneralAnswer<object>> InsertAsync(User user)
        {
            return await _userPersistencePort.InsertAsync(user);
        }

        public async Task<GeneralAnswer<object>> UpdateAsync(User user)
        {
            return await _userPersistencePort.UpdateAsync(user);
        }

        public async Task<GeneralAnswer<object>> DeleteAsync(int userId)
        {
            return await _userPersistencePort.DeleteAsync(userId);
        }
    }
}
