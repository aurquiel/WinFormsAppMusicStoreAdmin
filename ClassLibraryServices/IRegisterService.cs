using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices
{
    public interface IRegisterService
    {
        Task<GeneralAnswerDto222<List<Register22>>> GetRegisters(int storeId, DateTime dateInit, DateTime dateEnd);
        Task<GeneralAnswerDto222<List<Register22>>> GetRegisterByMonth(int storeId, DateTime date);
        Task<GeneralAnswerDto222<object>> RegisterInsert(Register22 register);
        Task<GeneralAnswerDto222<object>> RegisterDelete(int storeId);
    }
}
