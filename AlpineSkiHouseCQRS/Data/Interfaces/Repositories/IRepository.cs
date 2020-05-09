using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AlpineSkiHouseCQRS.Data.Interfaces.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll();
        Task<T> Get(Guid id);
        IEnumerable<T> Find(Func<T, bool> predicate);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
