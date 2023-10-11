using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IFileManagerDriving
    {
        string GetAudioStoreAdminPath();
        string GetLocalDbPath();
        void CopyLocalDbIfNotExist();
        void CreateDictoriesAndFiles(List<Store> stores);
        void CreateDictoryAndFile(string storeCode);
        void DeleteDictory(string storeCode);

        void EraseAudiosNotInAudioList(List<string> audioList, string storeCode);
        List<string> GetAudioListToDownload(List<string> audioList, string storeCode);
    }
}
