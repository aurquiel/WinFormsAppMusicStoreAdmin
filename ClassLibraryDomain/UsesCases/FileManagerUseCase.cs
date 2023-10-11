using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using ClassLibraryDomain.Ports.Driving;

namespace ClassLibraryDomain.UsesCases
{
    public class FileManagerUseCase : IFileManagerDriving
    {
        private readonly IFileManagerPersistencePort _fileManagerPersistencePort;

        public FileManagerUseCase(IFileManagerPersistencePort fileManagerPersistencePort)
        {
            _fileManagerPersistencePort = fileManagerPersistencePort;
        }

        public void CopyLocalDbIfNotExist()
        {
            _fileManagerPersistencePort.CopyLocalDbIfNotExist();
        }

        public string GetLocalDbPath()
        {
            return _fileManagerPersistencePort.GetLocalDbPath();
        }

        public void CreateDictoriesAndFiles(List<Store> stores)
        {
            _fileManagerPersistencePort.CreateDictoriesOfStores(stores);
        }

        public void CreateDictoryAndFile(string storeCode)
        {
            _fileManagerPersistencePort.CreateDictoryOfStore(storeCode);
        }

        public void DeleteDictory(string storeCode)
        {
            _fileManagerPersistencePort.DeleteDictoryOfStore(storeCode);
        }

        public void EraseAudiosNotInAudioList(List<string> audioList, string storeCode)
        {
            _fileManagerPersistencePort.EraseAudiosNotInAudioList(audioList, storeCode);
        }

        public List<string> GetAudioListToDownload(List<string> audioList, string storeCode)
        {
            return _fileManagerPersistencePort.GetAudioListToDownload(audioList, storeCode);
        }

        public string GetAudioStoreAdminPath()
        {
            return _fileManagerPersistencePort.GetAudioStoreAdminPath();
        }
    }
}
