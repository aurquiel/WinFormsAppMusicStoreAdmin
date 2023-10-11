using ClassLibraryDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDomain.Ports.Driving
{
    public interface IExcelDriving
    {
        Task<GeneralAnswer<object>> ExportRegisters(List<Register> listRegisters, List<Store> stores, string path);
    }
}
