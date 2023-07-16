using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public class FileManager : IFileManager
    {
        private readonly string AUIDO_LIST_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicStore\\data\\audioList.txt";
        private readonly string AUIDO_LIST_FILE = "audioList.txt";
        private readonly string AUIDO_PATH = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\MusicStore\\data\\audio\\";

        public string GetAudioListPath()
        {
            return AUIDO_LIST_PATH;
        }

        public string GetAudioListFileName()
        {
            return AUIDO_LIST_FILE;
        }

        public string GetAudioPath()
        {
            return AUIDO_PATH;
        }

        public async Task<GeneralAnswer<List<AudioOperation>>> GetAudioList()
        {
            List<AudioOperation> list = new();
            try
            {
                if (File.Exists(AUIDO_LIST_PATH))
                {
                    new List<string>(await File.ReadAllLinesAsync(AUIDO_LIST_PATH)).ForEach(x => list.Add(new AudioOperation { Name = x }));
                    return new GeneralAnswer<List<AudioOperation>> { status = true, statusMessage = "Audios obtenidos de archivo del equipo.", data = list };
                }

                return new GeneralAnswer<List<AudioOperation>> { status = false, statusMessage = "Archivo de audio no existe en el equipo.", data = list };
            }
            catch (Exception ex)
            {
                return new GeneralAnswer<List<AudioOperation>> { status = false, statusMessage = "Error al obtener archivo de audio del equipo, Excepcion: " + ex.Message, data = list };
            }
        }

        public GeneralAnswer<object> FileAlreadyExits(string nameFile)
        {
            if (File.Exists(AUIDO_PATH + nameFile))
            {
                return new GeneralAnswer<object> { status = true, statusMessage = "Archivo ya existente, archivo: " + nameFile, data = null };
            }

            return new GeneralAnswer<object> { status = false, statusMessage = "Archivo no existente, archivo: " + nameFile, data = null };

        }
    }
}