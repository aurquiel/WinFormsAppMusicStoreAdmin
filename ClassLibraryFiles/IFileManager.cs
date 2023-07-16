using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public interface IFileManager
    {
        string GetAudioListPath();
        string GetAudioListFileName();
        string GetAudioPath();

        Task<GeneralAnswer<List<AudioOperation>>> GetAudioList();
        GeneralAnswer<object> FileAlreadyExits(string nameFile);
    }
}