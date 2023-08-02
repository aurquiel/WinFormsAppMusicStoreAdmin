﻿using ClassLibraryModels;
using System.Text;
using static System.Formats.Asn1.AsnWriter;

namespace ClassLibraryFiles
{
    public class FileManager : IFileManager
    {
        private readonly string AUDIO_STORE_ADMIN_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\AudioStoreAdmin\\data";

        public string GetAudioStoreAdminPath()
        { 
            return AUDIO_STORE_ADMIN_PATH; 
        }

        public void CreateDictoryAndFile(string storeCode)
        {
            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}"))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}");
            }

            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}" + "\\audio"))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}" + "\\audio");
            }

            if (!File.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audioList{storeCode}.bin"))
            {
                var s = File.Create(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audioList{storeCode}.bin");
                s.Close();
            }
        }

        public void DeleteDictory(string storeCode)
        {
            if (Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}"))
            {
                Directory.Delete(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}", true);
            }
        }

        public void CreateDictoriesAndFiles(List<Store> stores)
        {
            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH);
            }

            foreach (Store store in stores)
            {
                if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{store.code}"))
                {
                    Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{store.code}");
                }

                if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{store.code}" + "\\audio"))
                {
                    Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH + $"\\{store.code}" + "\\audio");
                }

                if (!File.Exists(AUDIO_STORE_ADMIN_PATH + $"\\{store.code}\\audioList{store.code}.bin"))
                {
                    var s = File.Create(AUDIO_STORE_ADMIN_PATH + $"\\{store.code}\\audioList{store.code}.bin");
                    s.Close() ;
                }
            }
        }

       

        public GeneralAnswer<object> WriteAudioListToBinaryFile(string audioList, string storeCode)
        {
            try
            {
                using (BinaryWriter binWriter = new BinaryWriter(new FileStream(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audioList{storeCode}.bin", FileMode.Create), Encoding.UTF8))
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(audioList);
                    binWriter.Write(System.Convert.ToBase64String(plainTextBytes));
                }
                return new GeneralAnswer<object>(true, "Lista de Audio escrita en archivo binario.", null);
            }
            catch(Exception ex)
            {
                return new GeneralAnswer<object> (false, "Error escribiendo Lista de Audio a archivo binario. Excepcion: " + ex.Message, null);
            }   
        }

        public GeneralAnswer<List<string>> ReadAudioListFromBinaryFile(string storeCode)
        {
            try
            {
                List<string> audioList = new List<string>();
                using (BinaryReader binReader = new BinaryReader(File.OpenRead(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audioList{storeCode}.bin"), Encoding.UTF8))
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(binReader.ReadString());
                    audioList = new List<string>(System.Text.Encoding.UTF8.GetString(base64EncodedBytes).Split(Environment.NewLine));
                }
                return new GeneralAnswer<List<string>>(true, "Lista de Audio obtenida de archivo binario.", audioList);
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<string>>(false, "Error al  obtener Lista de Audio de archivo binario. Excepcion: " + ex.Message, null);
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
                    if(audio == Path.GetFileName(item))
                    {
                        File.Delete(item);
                    }
                }      
            }
        }

        public List<string> GetAudioListToDownload(List<string> listAudioFormServer, string storeCode)
        {
            List<string> listAudioPc = new List<string>();
            foreach(var item in Directory.GetFiles(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audio"))
            {
                listAudioPc.Add(Path.GetFileName(item));
            }
            
            return listAudioFormServer.Except(listAudioPc).ToList();

        }

    }
}