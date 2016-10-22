using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApp.DataAccess.Repository
{
    //Generic repository pattern, for an T type object with a K type key
    public interface IRepository<T, K>
        where T : class
        where K : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        T GetItem(K id);
        void Add(T item);
        void Update(T item);
        void Delete(K id);
    }
}
