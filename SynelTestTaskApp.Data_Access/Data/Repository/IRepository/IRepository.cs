using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynelTestTaskApp.Data_Access.Data.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);

        T Get(int id);

        IEnumerable<T> GetAll();

        void Remove(int id);
       

        void Save();
    }
}
