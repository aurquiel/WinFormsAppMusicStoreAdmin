using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class GeneralAnswerDto222<T> where T : class
    {
        public bool status { get; set; }
        public string? statusMessage { get; set; }
        public T? data { get; set; }

        public GeneralAnswerDto222()
        {

        }

        public GeneralAnswerDto222(bool status, string? statusMessage, T? data)
        {
            this.status = status;
            this.statusMessage = statusMessage;
            this.data = data;
        }
    }
}
