using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AntechLicense.GenericRepositoryP;
using AntechLicense.DBFactory;

namespace AntechLicense.UnitOfWork
{
    //public interface IUnitOfWork<TContext> where TContext : DbContext
    public interface IUnitOfWork
    {
        //public DbFactory DbFactoryContext;
        public void CreateTransaction();
        public void CommitTransaction();
        public void RollBackTransaction();
        public void SaveTransaction();
    }
}
