using Permit.Model.Entities;
using System;
using System.Linq;

namespace Permit.Repository
{
    public interface IBaseRepository<T>
    {
        bool Any(int id);
        T Get(int id);
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        bool Commit();
    }
}
