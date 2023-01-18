using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using Permit.Services.DTOs;

namespace Permit.Service.FluentValidations
{
    public class PermissionTypeValitador : AbstractValidator<PermissionTypeDTO>
    {
        public PermissionTypeValitador()
        {
            RuleFor(customer => customer.Id).NotNull();
            RuleFor(customer => customer.Description).NotNull();
        }
    }
}
