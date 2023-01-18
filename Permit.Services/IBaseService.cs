using Permit.Core;
using System;
using System.Collections.Generic;

namespace Permit.Services
{
    public interface IBaseService<EntityDto>
    {
        public EntityDto GetById(int id);
        public IOperationResult Add(EntityDto entity);
        public IOperationResult Update(EntityDto entity);
        public IEnumerable<EntityDto> GetAll();
        public IOperationResult Delete(int id);
    }
}
