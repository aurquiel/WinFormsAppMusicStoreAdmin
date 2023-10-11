using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IUserDriving
    {
        Task<GeneralAnswer<List<User>>> GetAllAsync();
        Task<GeneralAnswer<object>> InsertAsync(User user);
        Task<GeneralAnswer<object>> UpdateAsync(User user);
        Task<GeneralAnswer<object>> DeleteAsync(int userId);
    }
}
