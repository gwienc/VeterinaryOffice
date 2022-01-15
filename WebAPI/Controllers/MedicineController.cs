using Application.DTO.Medicine;
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

        [HttpPost]
        [SwaggerOperation(Summary = "Add new medicine")]
        public IActionResult Create(CreateMedicineDto medicine)
        {
            var newMedicine = _medicineService.AddNewMedicine(medicine);
            return CreatedAtAction(nameof(GetById), new { id = newMedicine.Id }, newMedicine);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific medicine by Id")]
        public IActionResult Update(int id, UpdateMedicineDto medicie)
        {
            var updatingMedicine = _medicineService.GetMedicineById(id);
            if (updatingMedicine != null)
            {
                _medicineService.UpdateMedicine(id, medicie);
                return NoContent();
            }
            return NotFound();
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
