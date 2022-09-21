using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AntechLicense.Models;
using AntechLicense.DBFactory;
using AntechLicense.ManagementDomain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using AntechLicense.UnitOfWork;

namespace AntechLicense.GenericRepositoryP
{
    public class GenericRepositoryP<T> : IGenericRepositoryP<T> where T : class
    {
        private bool _isDisposed;
        private DbSet<T> _dbSet;
        public readonly DbFactory dbFactoryContext;

        public GenericRepositoryP(UnitOfWork.UnitOfWork unitOfWork)
        {
            dbFactoryContext = unitOfWork.DbFactoryContext;
        }
        protected DbSet<T> DbSet
        {
            get => _dbSet ?? (_dbSet = dbFactoryContext.DbContext.Set<T>());
        }


        public void Add(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).CreatedDate = DateTime.UtcNow;
            }
            DbSet.Add(entity);
        }

        public void Delete(T entity)
        {
            if (typeof(IDeleteEntity).IsAssignableFrom(typeof(T)))
            {
                ((IDeleteEntity)entity).IsDeleted = true;
                DbSet.Update(entity);
            }
            else
                DbSet.Remove(entity);
        }

        public IQueryable List(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression);
        }

        public void Update(T entity)
        {
            if (typeof(IAuditEntity).IsAssignableFrom(typeof(T)))
            {
                ((IAuditEntity)entity).UpdatedDate = DateTime.UtcNow;
            }
            DbSet.Update(entity);
        }

        public IEnumerable<T> GetAll()
        {
            return DbSet.ToList();
        }

        public Expression<Func<T, bool>> FilterById(int Id)
        {
            return x => x.Equals(Id);
        }

        public Expression<Func<T, bool>> FilterIdUsr(int Id, string Usr)
        {
            return (x => x.Equals(Id) && x.Equals(Usr));
        }

        public T GetId(int Id)
        {            
            return DbSet.Find(FilterById(Id));
        }
    }
}
