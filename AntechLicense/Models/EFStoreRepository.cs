using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AntechLicense.Models
{
    public class EFStoreRepository : IStoreRepository
    {
        private DataContext context;

        public EFStoreRepository(DataContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Licencia> Licencias => context.Licencias;

        public void CreateLicencia(Licencia l)
        {
            context.Add(l);
            context.SaveChanges();
        }
        public void DeleteLicencia(Licencia l)
        {
            context.Remove(l);
            context.SaveChanges();
        }
        public void SaveLicencia(Licencia l)
        {
            context.SaveChanges();
        }
    }
}
