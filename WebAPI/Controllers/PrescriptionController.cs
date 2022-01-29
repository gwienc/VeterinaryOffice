using Application.DTO.Prescription;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
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
    public class PrescriptionController : ControllerBase
    {
        private readonly IPrescriptionService _prescriptionService;

        public PrescriptionController(IPrescriptionService prescriptionService)
        {
            _prescriptionService = prescriptionService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all prescriptions")]
        public IActionResult Get()
        {
            var prescriptions = _prescriptionService.GetAllPrescriptions();
            return Ok(prescriptions);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get a specific prescription by Id")]
        public IActionResult GetById(int id)
        {
            var prescription = _prescriptionService.GetPrescriptionById(id);
            if (prescription != null)
            {
                return Ok(prescription);
            }
            return NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Create a new prescription")]
        public IActionResult Create(CreatePrescriptionDto prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newPrescription = _prescriptionService.AddNewPrescription(prescription);
                return CreatedAtAction(nameof(GetById), new { id = newPrescription.Id }, newPrescription);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific prescription by Id")]
        public IActionResult Update(int id, UpdatePrescriptionDto prescription)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatingPrescription = _prescriptionService.GetPrescriptionById(id);
                if (updatingPrescription != null)
                {
                    _prescriptionService.UpdatePrescription(id, prescription);
                    return NoContent();
                }
                return NotFound();
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
           
        }

        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Update a specific prescription properties by prescription Id")]
        public IActionResult PartialUpdate(int id, JsonPatchDocument<UpdatePrescriptionDto> prescription)
        {
            try
            {
                var updatingPrescription = _prescriptionService.GetPrescriptionById(id);
                if (updatingPrescription != null)
                {
                    var prescriptionToPatch = _prescriptionService.PartialUpdatePrescription(id, prescription);
                    if (!TryValidateModel(prescriptionToPatch))
                    {
                        return ValidationProblem(ModelState);
                    }

                    _prescriptionService.UpdatePrescription(id, prescriptionToPatch);

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
        [SwaggerOperation(Summary = "Delete a specific prescription by Id")]
        public IActionResult Delete(int id)
        {
            var deletingPrescription = _prescriptionService.GetPrescriptionById(id);
            if (deletingPrescription != null)
            {
                _prescriptionService.DeletePrescription(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
