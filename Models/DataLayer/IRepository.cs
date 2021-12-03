using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesApp.Models
{
    public interface IRepository<T>
    {
        IEnumerable<T> List(QueryOptions<T> options);
        T Get(int id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
