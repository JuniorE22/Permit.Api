using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using FluentValidation;
using Permit.Services.DTOs;

namespace Permit.Services.FluentValidations
{
    public class PermissionValidator : AbstractValidator<PermissionDTO>
    {
        public PermissionValidator()
        {
            RuleFor(customer => customer.Id).NotNull();
            RuleFor(customer => customer.Name).NotNull();
            RuleFor(customer => customer.LastName).NotNull();
            RuleFor(customer => customer.PermitType).NotNull();
        }
    }
}
