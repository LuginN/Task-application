using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;

namespace TaskApp.DAL
{
    public interface IGenericRepository<T> 
        where T : class, new()
    {
        IQueryable<T> Get();
        void Insert(T entity);
        void Update(T entityToUpdate);
        void Delete(T entityToDelete);

        void Save();
    }
}