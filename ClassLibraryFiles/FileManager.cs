using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public class FileManager : IFileManager
    {
        private readonly string AUIDO_LIST_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicStore\\data\\audioList.txt";
        private readonly string AUIDO_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicStore\\data\\audio";


        public async Task<GeneralAnswer<List<AudioOperation>>> GetAudioList()
        {
            List<AudioOperation> list = new();
            try
            {
                if (File.Exists(AUIDO_LIST_PATH))
                {
                    new List<string>(await File.ReadAllLinesAsync(AUIDO_LIST_PATH)).ForEach(x => list.Add(new AudioOperation { Name = x }));
                    return new GeneralAnswer<List<AudioOperation>> { status = true, statusMessage = "Audios obtenidos de archivo.", data = list };
                }

                return new GeneralAnswer<List<AudioOperation>> { status = false, statusMessage = "Archivo de audio no existe.", data = list };
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<AudioOperation>> { status = false, statusMessage = "Error al obtener archivo de audio, Excepcion: " + ex.Message, data = list };
            }
        }
    }
}