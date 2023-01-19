using AutoMapper;
using FluentValidation;
using Permit.Core;
using Permit.Model.Entities;
using Permit.Repository;
using Permit.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Permit.Services
{
    public class PermissionTypeService : IBaseService<PermissionTypeDTO>
    {
        protected readonly IBaseRepository<PermissionType> _permissionTypeRepository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<PermissionTypeDTO> _validator;
        public PermissionTypeService(IBaseRepository<PermissionType> permissionTypeRepository, IMapper mapper, IValidator<PermissionTypeDTO> validator)
        {
            _permissionTypeRepository = permissionTypeRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public PermissionTypeDTO GetById(int id)
        {
            var permission = _permissionTypeRepository.Get(id);
            return _mapper.Map<PermissionTypeDTO>(permission);
        }

        public IEnumerable<PermissionTypeDTO> GetAll()
        {
            var allPermission = _permissionTypeRepository.GetAll().ToList();
            var maplist = _mapper.Map<IEnumerable<PermissionTypeDTO>>(allPermission);
            return maplist;
        }
        public IOperationResult Add(PermissionTypeDTO entity)
        {
            var results = _validator.Validate(entity);
            if (!results.IsValid)
            {
                return new OperationResult(true, "Data invalid");
            }

            if (_permissionTypeRepository.Any(entity.Id))
            {
                return new OperationResult(false, "El Permiso existe");
            }
            var permissionType = _mapper.Map<PermissionType>(entity);
            _permissionTypeRepository.Add(permissionType);
            return new OperationResult(true, "El Permiso ha sido agregado");
        }
        public IOperationResult Update(PermissionTypeDTO dto)
        {
            var results = _validator.Validate(dto);
            if (!results.IsValid)
            {
                return new OperationResult(true, "Data invalid");
            }
            if (!_permissionTypeRepository.Any(dto.Id))
                return new OperationResult(false, "Permiso no pudo ser actulizado");

            var entity = _permissionTypeRepository.Get(dto.Id);
            _mapper.Map(dto, entity);

            _permissionTypeRepository.Update(entity);
            return new OperationResult(true, "Permiso actulizado");
        }
        public IOperationResult Delete(int id)
        {
            if (!_permissionTypeRepository.Any(id))
            {
                return new OperationResult(false, "Permiso no pudo ser encontrado");
            }
            _permissionTypeRepository.Delete(id);
            return new OperationResult(true, "Permiso Eliminado");
        }
    }
}
