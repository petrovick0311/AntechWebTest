using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Models
{
    public interface IStoreRepository
    {
        IQueryable<Licencia> Licencias { get; }

        void SaveLicencia(Licencia l);
        void CreateLicencia(Licencia l);
        void DeleteLicencia(Licencia l);
    }
}
    

