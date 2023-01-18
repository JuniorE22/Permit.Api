using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Permit.Services;
using Permit.Services.DTOs;
using System.Collections.Generic;

namespace Permit.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersmissionController : ControllerBase
    {
        private readonly IBaseService<PermissionDTO> _permissionServices;

        public PersmissionController(IBaseService<PermissionDTO> permissionServices)
        {
            _permissionServices = permissionServices;
        }

        [HttpGet]
        public IEnumerable<PermissionDTO> GetAll()
        {
            return _permissionServices.GetAll();
        }

        [HttpGet("{id}")]
        public PermissionDTO GetById([FromRoute] int id)
        {
            return _permissionServices.GetById(id);
        }

        [HttpPost]
        public IActionResult Add([FromBody] PermissionDTO value)
        {
            _permissionServices.Add(value);
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] PermissionDTO value)
        {
            if (id != value.Id)
                return BadRequest();

            _permissionServices.Update(value);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove([FromRoute] int id)
        {
            _permissionServices.Delete(id);
            return Ok();
        }
    }
}
