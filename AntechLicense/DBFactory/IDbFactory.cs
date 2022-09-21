using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AntechLicense.Models;

namespace AntechLicense.DBFactory
{
    //public interface IDbFactory<TContext> where TContext : DbContext, new()
    //{
    //    public TContext DbContext { get; }
    //}

    public interface IDbFactory
    {
        public DbContext DbContext { get; }
    }
}
