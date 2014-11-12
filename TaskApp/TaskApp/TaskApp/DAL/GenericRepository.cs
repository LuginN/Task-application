using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TaskApp.DAL
{
    public abstract class GenericRepository<T> : IGenericRepository<T>
        where T: class, new()
    {
        private TaskAppDBContext _context;
        private DbSet<T> _entitySet;

        public GenericRepository(TaskAppDBContext context)
        {
            _context = context;
            _entitySet = _context.Set<T>();
        }

        public IQueryable<T> Get()
        {
            return _entitySet.AsQueryable<T>();
        }

        public void Insert(T entity)
        {
            _entitySet.Add(entity);
        }

        public void Update(T entityToUpdate)
        {
            _entitySet.Attach(entityToUpdate);
            _context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public void Delete(T entityToDelete)
        {
            if(_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                _entitySet.Attach(entityToDelete);
            }

            _entitySet.Remove(entityToDelete);
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }
}