using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public interface IFileManager
    {
        string GetAudioStoreAdminPath();
        void CreateDictoriesAndFiles(List<Store> stores);
        void CreateDictoryAndFile(string storeCode);
        void DeleteDictory(string storeCode);

        Task<GeneralAnswer<List<OperationDetails>>> GetAudioList(string storeCode);
        GeneralAnswer<object> WriteAudioListToBinaryFile(string audioList, string storeCode);
        GeneralAnswer<List<string>> ReadAudioListFromBinaryFile(string storeCode);
        void EraseAudiosNotInAudioList(List<string> audioList, string storeCode);
        List<string> GetAudioListToDownload(List<string> listAudioFormServer, string storeCode);
    }
}