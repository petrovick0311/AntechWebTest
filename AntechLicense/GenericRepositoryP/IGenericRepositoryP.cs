using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AntechLicense.GenericRepositoryP
{
    //public interface IGenericRepositoryP<T> where T: class
    public interface IGenericRepositoryP<T> where T : class
    {
        //IEnumerable<T> GetAll();  
        T GetId(int Id);
        void Add(T entity);        
        //void Update(T obj);
        //void Delete(T obj);

        //IQueryable List(Expression<Func<T, bool>> expression);
    }
}
