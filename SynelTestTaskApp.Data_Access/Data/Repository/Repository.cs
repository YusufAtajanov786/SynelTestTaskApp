using Microsoft.EntityFrameworkCore;
using SynelTestTaskApp.Data_Access.Data.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelTestTaskApp.Data_Access.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _dbContext;
        internal DbSet<T> _dbSet;
        public Repository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet;
        }

        public void Remove(int id)
        {
            var data = _dbSet.Find(id);
            if (data != null)
            {
                _dbSet.Remove(data);
            }
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }
    }
}
