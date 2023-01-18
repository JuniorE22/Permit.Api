using System;
using System.Collections.Generic;
using System.Text;

namespace Permit.Services.DTOs
{
    public class PermissionDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PermitType { get; set; }
        public PermissionDTO()
        {

        }
    }
}
