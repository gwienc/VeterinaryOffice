using Application.DTO.Vet;
using Application.IServices;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VetController : ControllerBase
    {
        private readonly IVetService _vetService;

        public VetController(IVetService vetService)
        {
            _vetService = vetService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all vets")]
        public IActionResult Get()
        {
            var vets = _vetService.GetAllVets();
            return Ok(vets);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a specific vet by Id")]
        public IActionResult GetById(int id)
        {
            var vet = _vetService.GetVetById(id);
            
            if (vet != null)
            {
                return Ok(vet);
            }
            return NotFound();          
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new vet")]
        public IActionResult Create(CreateVetDto vet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newVet = _vetService.AddNewVet(vet);
            return CreatedAtAction(nameof(GetById), new { id = newVet.Id }, newVet);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific vet by Id")]
        public IActionResult Update(int id, UpdateVetDto vet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedVet = _vetService.GetVetById(id);
            if (updatedVet != null)
            {
                _vetService.UpdateVet(id, vet);
                return NoContent();
            }
            return NotFound();           
        }

        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Update a specific vet properties by vet Id")]
        public IActionResult PartialUpdate(int id, JsonPatchDocument<UpdateVetDto> vet)
        {
            try
            {
                var updatingVet = _vetService.GetVetById(id);
                if (updatingVet != null)
                {
                    var vetToPatch = _vetService.PartialUpdateVet(id, vet);
                    if (!TryValidateModel(vetToPatch))
                    {
                        return ValidationProblem(ModelState);
                    }

                    _vetService.UpdateVet(id, vetToPatch);

                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary ="Delete a specific vet by Id")]
        public IActionResult Delete(int id)
        {
            var deletedVet = _vetService.GetVetById(id);
            if (deletedVet != null)
            {
                _vetService.DeleteVet(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
