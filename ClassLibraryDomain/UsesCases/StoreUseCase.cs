using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;

namespace ClassLibraryDomain.UsesCases
{
    public class StoreUseCase : IStoreDriving
    {
        private readonly IStorePersistencePort _storePersistencePort;
        private readonly IFileManagerPersistencePort _fileManagerPersistencePort;
        private readonly IAudioListLocalPersistencePort _audioListLocalPersistencePort;

        public StoreUseCase(IStorePersistencePort storePersistencePort, IFileManagerPersistencePort fileManagerPersistencePort, 
            IAudioListLocalPersistencePort audioListLocalPersistencePort)
        {
            _storePersistencePort = storePersistencePort;
            _fileManagerPersistencePort = fileManagerPersistencePort;
            _audioListLocalPersistencePort = audioListLocalPersistencePort;
        }

        public async Task<GeneralAnswer<List<Store>>> GetAllAsync()
        {
            return await _storePersistencePort.GetAllAsync();
        }

        public async Task<GeneralAnswer<object>> InsertAsync(Store store)
        {
            var result = await _storePersistencePort.InsertAsync(store);
            
            if(result.status)
            {
                _fileManagerPersistencePort.CreateDictoryOfStore(store.Code);
            }
            
            return result;
        }

        public async Task<GeneralAnswer<object>> UpdateAsync(Store store)
        {
            var result = await _storePersistencePort.UpdateAsync(store);
            {
                _fileManagerPersistencePort.CreateDictoryOfStore(store.Code);
            }

            return result;
        }

        public async Task<GeneralAnswer<object>> DeleteAsync(int storeId, string storeCode)
        {
            var result =  await _storePersistencePort.DeleteAsync(storeId);
            
            if(result.status)
            {
                _fileManagerPersistencePort.DeleteDictoryOfStore(storeCode);
                await _audioListLocalPersistencePort.DeleteAudioListAsync(storeId);
            }

            return result;
        }
    }
}
