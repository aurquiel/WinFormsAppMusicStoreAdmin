using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppMusicStoreAdmin.DrivingAdapters.Winforms.Dtos
{
    public class RegisterDisplay
    {
        public string storeCode { get; set; }
        public string activity { get; set; }
        public string message { get; set; }
        public DateTime creationDateTime { get; set; }
    }
}
