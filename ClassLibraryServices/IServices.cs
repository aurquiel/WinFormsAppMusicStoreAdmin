﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryServices
{
    public interface IServices
    {
        public IUserService UserService { get; set; }
    }
}
