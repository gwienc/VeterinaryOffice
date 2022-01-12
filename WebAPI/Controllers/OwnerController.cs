using Application.DTO.Owner;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all owners")]
        public IActionResult Get()
        {
            var owners = _ownerService.GetAllOwners();
            return Ok(owners);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific owner by Id")]
        public IActionResult GetById(int id)
        {
            var owner = _ownerService.GetOwnerById(id);
            if (owner != null)
            {
                return Ok(owner);
            }
            return NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new owner")]
        public IActionResult Create(CreateOwnerDto owner)
        {
            var newOwner = _ownerService.AddNewOwner(owner);
            return CreatedAtAction(nameof(GetById), new { id = newOwner.Id }, newOwner);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific owner by Id")]
        public IActionResult Update(int id, UpdateOwnerDto owner)
        {
            var updatedOwner = _ownerService.GetOwnerById(id);
            if (updatedOwner != null)
            {
                _ownerService.UpdateOwner(id,owner);
                return NoContent();
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a specific owner by Id")]
        public IActionResult Delete(int id)
        {
            var deletedOwner = _ownerService.GetOwnerById(id);
            if (deletedOwner != null)
            {
                _ownerService.DeleteOwner(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
