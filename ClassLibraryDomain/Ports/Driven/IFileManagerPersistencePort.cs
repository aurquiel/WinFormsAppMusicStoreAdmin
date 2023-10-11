using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driven
{
    public interface IFileManagerPersistencePort
    {
        string GetAudioStoreAdminPath();
        string GetLocalDbPath();
        void CopyLocalDbIfNotExist();
        void CreateDictoriesOfStores(List<Store> stores);
        void CreateDictoryOfStore(string storeCode);
        void DeleteDictoryOfStore(string storeCode);

        void EraseAudiosNotInAudioList(List<string> audioList, string storeCode);
        List<string> GetAudioListToDownload(List<string> audioList, string storeCode);
    }
}
