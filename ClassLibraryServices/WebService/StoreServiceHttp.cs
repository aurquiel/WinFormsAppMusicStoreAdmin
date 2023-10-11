using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices.WebService
{
    internal class StoreServiceHttp : IStoreService
    {
        private WebServiceParams22 _webParams;

        public StoreServiceHttp(WebServiceParams22 webParams)
        {
            _webParams = webParams;
        }

        public async Task<GeneralAnswerDto222<List<Store22>>> StoreGetAll()
        {
            var result = await StoreHttp.StoreGetAll(_webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<Store22>>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<List<Store22>>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> StoreCrete(Store22 store)
        {
            var result = await StoreHttp.StorePost(store, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> StoreUpdate(Store22 store)
        {
            var result = await StoreHttp.StorePut(store, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item3.status, result.Item3.statusMessage, result.Item3.data);
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswerDto222<object>(result.Item1, result.Item2, null);
            }
        }

        public async Task<GeneralAnswerDto222<object>> StoreDelete(Store22 store)
        {
            var result = await StoreHttp.StoreDelete(store, _webParams);

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
