using Application.DTO.Medicine;
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
    public class MedicineController : ControllerBase
    {
        private readonly IMedicineService _medicineService;

        public MedicineController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all medicines")]
        public IActionResult Get()
        {
            var medicines = _medicineService.GetAllMedicines();
            return Ok(medicines);
        }

        [HttpGet("GetWithAnimals")]
        [SwaggerOperation(Summary = "Get all medicines with animals")]
        public IActionResult GetWithAnimals()
        {
            var medicinesWithAnimals = _medicineService.GetAllMedicinesWithAnimals();
            return Ok(medicinesWithAnimals);
        }
        
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get specyfic medicine by Id")]
        public IActionResult GetById(int id)
        {
            var exisitingMecicine = _medicineService.GetMedicineById(id);
            if (exisitingMecicine != null)
            {
                return Ok(exisitingMecicine);
            }
            return NotFound();
        }
        
        [HttpGet("GetByIdWithAnimals/{id}")]
        [SwaggerOperation(Summary = "Get specyfic medicine with animals by Id")]
        public IActionResult GetByIdWithAnimals(int id)
        {
            var exisitingMecicine = _medicineService.GetMedicineWithAnimalsById(id);
            if (exisitingMecicine != null)
            {
                return Ok(exisitingMecicine);
            }
            return NotFound();
        }       

        [HttpPost]
        [SwaggerOperation(Summary = "Add new medicine")]
        public IActionResult Create(CreateMedicineDto medicine)
        {
            var newMedicine = _medicineService.AddNewMedicine(medicine);
            return CreatedAtAction(nameof(GetById), new { id = newMedicine.Id }, newMedicine);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific medicine by Id")]
        public IActionResult Update(int id, UpdateMedicineDto medicine)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatingMedicine = _medicineService.GetMedicineById(id);
            if (updatingMedicine != null)
            {
                _medicineService.UpdateMedicine(id, medicine);
                return NoContent();
            }
            return NotFound();
        }

        [HttpPatch("{id}")]
        [SwaggerOperation(Summary = "Update a specific medicine properties by medicine Id")]
        public IActionResult PartialUpdate(int id, JsonPatchDocument<UpdateMedicineDto> medicine)
        {
            try
            {
                var updatingMedicine = _medicineService.GetMedicineById(id);
                if (updatingMedicine != null)
                {
                    var medicineToPatch = _medicineService.PartialUpdateMedicine(id, medicine);
                    if (!TryValidateModel(medicineToPatch))
                    {
                        return ValidationProblem(ModelState);
                    }

                    _medicineService.UpdateMedicine(id, medicineToPatch);

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
        [SwaggerOperation(Summary = "Delete a specific medicine by Id")]
        public IActionResult Delete(int id)
        {
            var deletingMedicine = _medicineService.GetMedicineById(id);
            if (deletingMedicine != null)
            {
                _medicineService.DeleteMedicine(id);
                return NoContent();
            }
            return NotFound();
           
        }
    }
}
