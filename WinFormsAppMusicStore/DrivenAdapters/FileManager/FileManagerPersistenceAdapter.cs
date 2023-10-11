using ClassLibraryDomain.Models;
using ClassLibraryDomain.Ports.Driven;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.FileManager
{
    public class FileManagerPersistenceAdapter : IFileManagerPersistencePort
    {
        private readonly string AUDIO_STORE_ADMIN_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AudioStoreAdmin\\data";
        private readonly string AUDIO_STORE_LOCAL_DB_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AudioStoreAdmin";

        public string GetAudioStoreAdminPath()
        {
            return AUDIO_STORE_ADMIN_PATH;
        }

        public string GetLocalDbPath()
        {
            return AUDIO_STORE_LOCAL_DB_PATH;
        }

        public void CreateDictoryOfStore(string storeCode)
        {
            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}"))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}");
            }

            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}" + "\\audio"))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}" + "\\audio");
            }
        }

        public void CreateDictoriesOfStores(List<Store> stores)
        {
            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH);
            }

            foreach (Store store in stores)
            {
                if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{store.Code}"))
                {
                    Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{store.Code}");
                }

                if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{store.Code}" + "\\audio"))
                {
                    Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{store.Code}" + "\\audio");
                }
            }
        }

        public void CopyLocalDbIfNotExist()
        {
            if(!File.Exists(AUDIO_STORE_LOCAL_DB_PATH + "\\AudioStoreLocal.db"))
            {
                File.WriteAllBytes(AUDIO_STORE_LOCAL_DB_PATH + "\\AudioStoreLocal.db", Properties.Resources.AudioStoreLocal);
            }
        }

        public void DeleteDictoryOfStore(string storeCode)
        {
            if (Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}"))
            {
                Directory.Delete(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}", true);
            }
        }

        public void EraseAudiosNotInAudioList(List<string> audioList, string storeCode)
        {
            List<string> listAudioPc = new List<string>();
            foreach (var item in Directory.GetFiles(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audio"))
            {
                listAudioPc.Add(Path.GetFileName(item));
            }

            List<string> notInAudioList = listAudioPc.Except(audioList).ToList();

            foreach (var audio in notInAudioList)
            {
                foreach (var item in Directory.GetFiles(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audio"))
                {
                    if (audio == Path.GetFileName(item))
                    {
                        File.Delete(item);
                    }
                }
            }
        }

        public List<string> GetAudioListToDownload(List<string> audioListFromServer, string storeCode)
        {
            List<string> listAudioPc = new List<string>();
            foreach (var item in Directory.GetFiles(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audio"))
            {
                listAudioPc.Add(Path.GetFileName(item));
            }

            return audioListFromServer.Except(listAudioPc).ToList();
        }

        
    }
}
