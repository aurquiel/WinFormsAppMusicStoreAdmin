using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public interface IFileManager
    {
        string GetAudioStoreAdminPath();
        void CreateDictoriesAndFiles(List<Store> stores);
        void CreateDictoryAndFile(string storeCode);
        void DeleteDictory(string storeCode);

        GeneralAnswer<object> WriteAudioListToBinaryFile(List<AudioFileDTO> audioList, string storeCode);
        GeneralAnswer<List<AudioFileDTO>> ReadAudioListFromBinaryFile(string storeCode);
        void EraseAudiosNotInAudioList(List<string> audioList, string storeCode);
        List<string> GetAudioListToDownload(List<string> listAudioFormServer, string storeCode);
    }
}