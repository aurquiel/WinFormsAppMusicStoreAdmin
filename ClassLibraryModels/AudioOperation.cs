﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryModels
{
    public class AudioOperation
    {
        public enum OPERATIONS { NONE =0, UPLOAD = 0, ERASE = 1}

        public string? Name { get; set; }
        public OPERATIONS Operation { get; set; } = OPERATIONS.NONE;
        public string? PathFileUpload { get; set; } = string.Empty;
    }
}
