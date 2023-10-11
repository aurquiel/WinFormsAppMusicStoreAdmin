using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IRegisterDriving
    {
        Task<GeneralAnswer<List<Register>>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd);
        Task<GeneralAnswer<List<Register>>> GetByIdAndMonthAsync(int storeId, DateTime date);
        Task<GeneralAnswer<object>> InsertAsync(List<Register> registers);
        Task<GeneralAnswer<object>> DeleteAllByStoreIdAsync(int storeId);
    }
}
