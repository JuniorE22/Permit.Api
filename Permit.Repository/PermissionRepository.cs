using Microsoft.EntityFrameworkCore;
using Permit.Model.Context;
using Permit.Model.Entities;
using System;
using System.Linq;

namespace Permit.Repository
{
    public class PermissionRepository : IBaseRepository<Permission>
    {
        private readonly PermitDbContext _dbContext;
        private readonly DbSet<Permission> _dbSet;
        public PermissionRepository(PermitDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Permissions;
        }
        public void Add(Permission entity)
        {
            _dbSet.Add(entity);
            Commit();
        }
        public bool Any(int id)
        {
            return GetAll().Any(x => x.Id == id);
        }
        public bool Commit()
        {
            var result = _dbContext.SaveChanges() == 1;
            return result;
        }

        public void Delete(int id)
        {
            var item = Get(id);
            _dbContext.Remove(item);
            Commit();
        }

        public Permission Get(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<Permission> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(Permission entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }
    }
}
