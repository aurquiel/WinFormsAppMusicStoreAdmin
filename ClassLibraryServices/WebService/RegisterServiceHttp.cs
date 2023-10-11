using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ClassLibraryServices.WebService
{
    internal class RegisterServiceHttp : IRegisterService
    {
        private WebServiceParams22 _webParams;

        public RegisterServiceHttp(WebServiceParams22 webParams)
        {
            _webParams = webParams;
        }

        public async Task<GeneralAnswerDto222<List<Register22>>> GetRegisterByMonth(int storeId, DateTime date)
        {
            var result = await RegisterHttp.RegisterGetByMonth(_webParams, storeId, date);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<Register22>>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<Register22>>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<List<Register22>>> GetRegisters(int storeId, DateTime dateInit, DateTime dateEnd)
        {
            var result = await RegisterHttp.RegisterGet(_webParams, storeId, dateInit, dateEnd);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<Register22>>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<Register22>>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> RegisterDelete(int storeId)
        {
            var result = await RegisterHttp.RegisterDelete(_webParams, storeId);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> RegisterInsert(Register22 register)
        {
            var result = await RegisterHttp.RegisterPost(_webParams, register);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }
    }
}
