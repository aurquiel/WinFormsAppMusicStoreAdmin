using ClassLibraryModels;

namespace ClassLibraryServices
{
    public interface IStoreService
    {
        public Task<GeneralAnswerDto222<List<Store22>>> StoreGetAll();
        public Task<GeneralAnswerDto222<object>> StoreCrete(Store22 stroe);
        public Task<GeneralAnswerDto222<object>> StoreUpdate(Store22 store);
        public Task<GeneralAnswerDto222<object>> StoreDelete(Store22 store);
    }
}
