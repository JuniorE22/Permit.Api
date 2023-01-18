using Microsoft.AspNetCore.Mvc;
using Permit.Services;
using Permit.Services.DTOs;
using System.Collections.Generic;

namespace Permit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersmissionTypeController : ControllerBase
    {
        private readonly IBaseService<PermissionTypeDTO> _permissionTypeServices;

        public PersmissionTypeController(IBaseService<PermissionTypeDTO> permissionTypeServices)
        {
            _permissionTypeServices = permissionTypeServices;
        }

        [HttpGet]
        public IEnumerable<PermissionTypeDTO> GetAll()
        {
            return _permissionTypeServices.GetAll();
        }

        [HttpGet("{id}")]
        public PermissionTypeDTO GetById([FromRoute] int id)
        {
            return _permissionTypeServices.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PermissionTypeDTO value)
        {
            _permissionTypeServices.Add(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PermissionTypeDTO value)
        {
            if (id != value.Id)
                return BadRequest();

            _permissionTypeServices.Update(value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _permissionTypeServices.Delete(id);
            return Ok();
        }
    }
}
