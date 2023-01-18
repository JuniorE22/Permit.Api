using Microsoft.EntityFrameworkCore;
using Permit.Model.Context;
using Permit.Model.Entities;
using System;
using System.Linq;

namespace Permit.Repository
{
    public class PermissionTypeRepository : IBaseRepository<PermissionType>
    {
        private readonly PermitDbContext _dbContext;
        private readonly DbSet<PermissionType> _dbSet;
        public PermissionTypeRepository(PermitDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.PermissionsType;
        }
        public void Add(PermissionType entity)
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

        public PermissionType Get(int id)
        {
            return _dbSet.Where(x => x.Id == id).FirstOrDefault();
        }

        public IQueryable<PermissionType> GetAll()
        {
            return _dbSet.AsQueryable();
        }

        public void Update(PermissionType entity)
        {
            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
            Commit();
        }
    }
}
