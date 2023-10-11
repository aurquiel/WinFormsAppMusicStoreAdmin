using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities
{
    public class SynchronizeAudioListStoreDto
    {
        public List<AudioFileDto> audioList { get; set; }
        public int storeId { get; set; }
    }
}
