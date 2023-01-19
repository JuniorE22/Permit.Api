using AutoMapper;
using Permit.Model.Entities;
using Permit.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Service.Map
{
    public class PermissionTypeProfile : Profile
    {
        public PermissionTypeProfile()
        {
            CreateMap<PermissionTypeDTO, PermissionType>();
            CreateMap<PermissionType, PermissionTypeDTO>();

        }
    }
}
