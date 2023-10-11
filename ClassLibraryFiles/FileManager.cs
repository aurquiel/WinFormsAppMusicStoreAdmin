using ClassLibraryModels;
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

        public void CreateDictoriesAndFiles(List<Store22> stores)
        {
            if (!Directory.Exists(AUDIO_STORE_ADMIN_PATH))
            {
                Directory.CreateDirectory(AUDIO_STORE_ADMIN_PATH);
            }

            foreach (Store22 store in stores)
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

       

        public GeneralAnswerDto222<object> WriteAudioListToBinaryFile(List<AudioFileSelect> audioList, string storeCode)
        {
            try
            {
                using (BinaryWriter binWriter = new BinaryWriter(new FileStream(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audioList{storeCode}.bin", FileMode.Create), Encoding.UTF8))
                {
                    var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(String.Join(Environment.NewLine, audioList.Select(x => x.name).ToArray()));
                    binWriter.Write(System.Convert.ToBase64String(plainTextBytes));
                }
                return new GeneralAnswerDto222<object>(true, "Lista de Audio escrita en archivo binario.", null);
            }
            catch(Exception ex)
            {
                return new GeneralAnswerDto222<object> (false, "Error escribiendo Lista de Audio a archivo binario. Excepcion: " + ex.Message, null);
            }   
        }

        public GeneralAnswerDto222<List<AudioFileSelect>> ReadAudioListFromBinaryFile(string storeCode)
        {
            try
            {
                List<string> audioList = new List<string>();
                using (BinaryReader binReader = new BinaryReader(File.OpenRead(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}\\audioList{storeCode}.bin"), Encoding.UTF8))
                {
                    var base64EncodedBytes = System.Convert.FromBase64String(binReader.ReadString());
                    audioList = new List<string>(System.Text.Encoding.UTF8.GetString(base64EncodedBytes).Split(Environment.NewLine));
                }
                var a = string.Join(Environment.NewLine, audioList);
                var audioFiles = new List<AudioFileSelect>();
                foreach (var audio in audioList)
                {
                    audioFiles.Add(new AudioFileSelect { name = audio, path = Path.Combine(AUDIO_STORE_ADMIN_PATH + $"\\{storeCode}" + "\\audio", audio) });
                }

                return new GeneralAnswerDto222<List<AudioFileSelect>>(true, "Lista de Audio obtenida de archivo binario.", audioFiles);
            }
            catch (Exception ex)
            {
                return new GeneralAnswerDto222<List<AudioFileSelect>>(false, "Error al  obtener Lista de Audio de archivo binario. Excepcion: " + ex.Message, null);
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