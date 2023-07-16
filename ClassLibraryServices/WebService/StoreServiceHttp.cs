﻿using ClassLibraryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices.WebService
{
    internal class StoreServiceHttp : IStoreService
    {
        private WebServiceParams _webParams;

        public StoreServiceHttp(WebServiceParams webParams)
        {
            _webParams = webParams;
        }

        public async Task<GeneralAnswer<List<Store>>> StoreGetAll()
        {
            var result = await StoreHttp.StoreGetAll(_webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<List<Store>> { status = result.Item3.status, statusMessage = result.Item3.statusMessage, data = result.Item3.data };
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<List<Store>> { status = result.Item1, statusMessage = result.Item2, data = null };
            }
        }

        public async Task<GeneralAnswer<object>> StoreCrete(Store store)
        {
            var result = await StoreHttp.StorePost(store, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object> { status = result.Item3.status, statusMessage = result.Item3.statusMessage, data = result.Item3.data };
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object> { status = result.Item1, statusMessage = result.Item2, data = null };
            }
        }

        public async Task<GeneralAnswer<object>> StoreUpdate(Store store)
        {
            var result = await StoreHttp.StorePut(store, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object> { status = result.Item3.status, statusMessage = result.Item3.statusMessage, data = result.Item3.data };
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object> { status = result.Item1, statusMessage = result.Item2, data = null };
            }
        }

        public async Task<GeneralAnswer<object>> StoreDelete(Store store)
        {
            var result = await StoreHttp.StoreDelete(store, _webParams);

            if (result.Item1) //Obtenido del servidor
            {
                return new GeneralAnswer<object> { status = result.Item3.status, statusMessage = result.Item3.statusMessage, data = result.Item3.data };
            }
            else // No Obtenido del servidor
            {
                return new GeneralAnswer<object> { status = result.Item1, statusMessage = result.Item2, data = null };
            }
        }
    }
}
