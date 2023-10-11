using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IStorePersistencePort
    {
        Task<GeneralAnswer<List<Store>>> GetAllAsync();
        Task<GeneralAnswer<object>> InsertAsync(Store store);
        Task<GeneralAnswer<object>> UpdateAsync(Store store);
        Task<GeneralAnswer<object>> DeleteAsync(int storeId);
    }
}
