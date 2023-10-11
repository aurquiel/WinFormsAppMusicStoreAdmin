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
    public class RegisterUseCase : IRegisterDriving
    {
        private readonly IRegisterPersistencePort _registerPersistencePort;

        public RegisterUseCase(IRegisterPersistencePort registerPersistencePort)
        {
            _registerPersistencePort = registerPersistencePort;
        }

        public async Task<GeneralAnswer<List<Register>>> GetByIdAndMonthAsync(int storeId, DateTime date)
        {
            return await _registerPersistencePort.GetByIdAndMonthAsync(storeId, date);
        }

        public async Task<GeneralAnswer<List<Register>>> GetByIdAndRangeDateAsync(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            return await _registerPersistencePort.GetByIdAndRangeDateAsync(storeId, dateInit, dateEnd);
        }

        public async Task<GeneralAnswer<object>> InsertAsync(List<Register> registers)
        {
            return await _registerPersistencePort.InsertAsync(registers);
        }

        public async Task<GeneralAnswer<object>> DeleteAllByStoreIdAsync(int storeId)
        {
            return await _registerPersistencePort.DeleteAllByStoreIdAsync(storeId);
        }

    }
}
