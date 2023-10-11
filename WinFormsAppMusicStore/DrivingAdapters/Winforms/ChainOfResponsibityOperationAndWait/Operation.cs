using ClassLibraryDomain.Models;
using WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos;
using static WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait.OperationTypes;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.ChainOfResponsibityOperationAndWait
{
    public class Operation
    {
        public Operation(OPERATIONS typeOfOperation, Store store, List<AudioFileSelect> audioFileToOperate)
        {
            TypeOfOperation = typeOfOperation;
            Store= store;
            AudioFileToOperate = audioFileToOperate;
        }

        public OPERATIONS TypeOfOperation { get; set; }
        public Store Store { get; set; }
        public List<AudioFileSelect> AudioFileToOperate { get; set; }
    }
}
