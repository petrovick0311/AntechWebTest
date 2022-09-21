using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AntechLicense.UnitOfWork;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using AntechLicense.GenericRepositoryP;
using AntechLicense.DBFactory;
using AntechLicense.Models;


namespace AntechLicense.UnitOfWork
{
    //public class UnitOfWork<TContext> : IUnitOfWork<TContext>, IDisposable where TContext : DbContext, new()
    //public class UnitOfWork<TContext>: DbFactory<TContext>, IUnitOfWork<TContext> where TContext : DbContext
    //public class UnitOfWork : DbFactory<TContext>, IUnitOfWork
    public class UnitOfWork : IUnitOfWork
    {
        //private readonly TContext _dbcontext;
        private readonly DbFactory _dbFactorycontext;
        private bool _disposed;        
        private Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction ContextTransaction;

        public UnitOfWork(DbContext FuncFactory)
        {
            _dbFactorycontext = new DbFactory(FuncFactory);
        }

        public UnitOfWork(Func<DbContext> FuncFactory)
        {
            _dbFactorycontext = new DbFactory(FuncFactory);
        }
        public DbFactory DbFactoryContext
        {
            get { return _dbFactorycontext; }
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}        
        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //        if (disposing)
        //            _dbcontext.Dispose();
        //    _disposed = true;
        //}
        public void CreateTransaction()
        {
            ContextTransaction = _dbFactorycontext.DbContext.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            ContextTransaction.Commit();
        }
        
        public void RollBackTransaction()
        {
            ContextTransaction.Rollback();
            ContextTransaction.Dispose();
        }

        public void SaveTransaction()
        {
            try
            {
                _dbFactorycontext.DbContext.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
