using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public interface IFileManager
    {
        string GetAudioStoreAdminPath();
        void CreateDictoriesAndFiles(List<Store22> stores);
        void CreateDictoryAndFile(string storeCode);
        void DeleteDictory(string storeCode);

        GeneralAnswerDto222<object> WriteAudioListToBinaryFile(List<AudioFileSelect> audioList, string storeCode);
        GeneralAnswerDto222<List<AudioFileSelect>> ReadAudioListFromBinaryFile(string storeCode);
        void EraseAudiosNotInAudioList(List<string> audioList, string storeCode);
        List<string> GetAudioListToDownload(List<string> listAudioFormServer, string storeCode);
    }
}