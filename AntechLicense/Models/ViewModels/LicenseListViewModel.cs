using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntechLicense.Models;

namespace AntechLicense.Models.ViewModels
{
    public class LicenseListViewModel
    {
        public IEnumerable<Licencia> Licencias { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string CurrentTipoLicencia { get; set; }
    }
}
