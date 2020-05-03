using System;
using System.Collections.Generic;

namespace AlpineSkiHouseCQRS.Data.Interfaces.Repositories
{
    public interface IRepository<T>
        where T : class
    {
        IEnumerable<T> GetAll(); 
        T Get(Guid id);
        IEnumerable<T> Find(Func<T, Boolean> predicate);
        void Create(T item); 
        void Update(T item); 
        void Delete(Guid id); 
        void Save(); 
    }
}
