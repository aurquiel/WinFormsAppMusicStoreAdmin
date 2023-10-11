using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsAppMusicStoreAdmin.DrivenAdapters.WebserviceAdapters.Entities
{
    public class StoreDto
    {
        public int id { get; set; }

        public string? code { get; set; }

        public DateTime creationDateTime { get; set; }
    }
}
