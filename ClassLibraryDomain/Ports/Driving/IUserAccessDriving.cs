﻿using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IUserAccessDriving
    {
        Task<GeneralAnswer<UserAccess>> AcccesLoginTokenAsync(string alias, string password);
    }
}
