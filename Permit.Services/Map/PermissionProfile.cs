using AutoMapper;
using Permit.Model.Entities;
using Permit.Services.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Article.Service.Map
{
    public class PermissionProfile : Profile
    {
        public PermissionProfile()
        {
            CreateMap<PermissionDTO, Permission>();
            CreateMap<Permission, PermissionDTO>();

        }
    }
}
