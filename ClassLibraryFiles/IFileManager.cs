using ClassLibraryModels;

namespace ClassLibraryFiles
{
    public interface IFileManager
    {
        Task<GeneralAnswer<List<AudioOperation>>> GetAudioList();
    }
}