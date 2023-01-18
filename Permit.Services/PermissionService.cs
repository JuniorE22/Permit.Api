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
    public class PermissionService : IBaseService<PermissionDTO>
    {
        protected readonly IBaseRepository<Permission> _permissionRepository;
        protected readonly IMapper _mapper;
        protected readonly IValidator<PermissionDTO> _validator;
        public PermissionService(IBaseRepository<Permission> permissionRepository, IMapper mapper, IValidator<PermissionDTO> validator)
        {
            _permissionRepository = permissionRepository;
            _mapper = mapper;
            _validator = validator;
        }
        public PermissionDTO GetById(int id)
        {
            var permission = _permissionRepository.Get(id);
            return _mapper.Map<PermissionDTO>(permission);
        }

        public IEnumerable<PermissionDTO> GetAll()
        {
            var allPermission = _permissionRepository.GetAll().ToList();
            var maplist = _mapper.Map<IEnumerable<PermissionDTO>>(allPermission);
            return maplist;
        }
        public IOperationResult Add(PermissionDTO entity)
        {
            var results = _validator.Validate(entity);
            if (!results.IsValid)
            {
                return new OperationResult(true, "Data invalid");
            }

            if (_permissionRepository.Any(entity.Id))
            {
                return new OperationResult(false, "El Permiso existe");
            }
            var article = _mapper.Map<Permission>(entity);
            _permissionRepository.Add(article);
            return new OperationResult(true, "El Permiso ha sido agregado");
        }
        public IOperationResult Update(PermissionDTO dto)
        {
            var results = _validator.Validate(dto);
            if (!results.IsValid)
            {
                return new OperationResult(true, "Data invalid");
            }
            if (!_permissionRepository.Any(dto.Id))
                return new OperationResult(false, "Permiso no pudo ser actulizado");

            var entity = _permissionRepository.Get(dto.Id);
            _mapper.Map(dto, entity);

            _permissionRepository.Update(entity);
            return new OperationResult(true, "Permiso actulizado");
        }
        public IOperationResult Delete(int id)
        {
            if (!_permissionRepository.Any(id))
            {
                return new OperationResult(false, "Permiso no pudo ser encontrado");
            }
            _permissionRepository.Delete(id);
            return new OperationResult(true, "Permiso Eliminado");
        }
    }
}
