using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AntechLicense.Models;

namespace AntechLicense.DBFactory
{    
    //public class DbFactory<TContext> : IDisposable, IDbFactory<TContext> where TContext : DbContext, new()
    public class DbFactory : IDisposable, IDbFactory
    {
        private bool _disposed;
        private Func<DbContext> _instanceFunc;
        private readonly DbContext _dbContext;
        public DbContext DbContext => _dbContext;// ?? (_dbContext = _instanceFunc.Invoke());

        public DbFactory(DbContext dbContextFactory)
        {
            _dbContext = dbContextFactory;
        }
        public DbFactory(Func<DbContext> dbContextFactory )
        {
            _instanceFunc = dbContextFactory;
        }
        public void Dispose()
        {
            if(!_disposed && _dbContext != null)
            {
                _disposed = true;
                _dbContext.Dispose();
            }
        }
    }
}
