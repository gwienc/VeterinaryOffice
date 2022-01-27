using Application.DTO.Animal;
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
    public class AnimalController : ControllerBase
    {
        private readonly IAnimalService _animalService;

        public AnimalController(IAnimalService animalService)
        {
            _animalService = animalService;
        }
        
        
        [HttpGet]
        [SwaggerOperation(Summary = "Get all animals")]
        public IActionResult Get()
        {
            var animals = _animalService.GetAllAnimals();
            return Ok(animals);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get specific animal by id")]
        public IActionResult GetById(int id)
        {
            var animal = _animalService.GetAnimalById(id);
            if (animal != null)
            {
                return Ok(animal);
            }
            return NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new animal")]
        public IActionResult Create(CreateAnimalDto animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var newAnimal = _animalService.AddNewAnimal(animal);
                return CreatedAtAction(nameof(GetById), new { id = newAnimal.Id }, newAnimal);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
            
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific animal by Id")]
        public IActionResult Update(int id, UpdateAnimalDto animal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatingAnimal = _animalService.GetAnimalById(id);
                if (updatingAnimal != null)
                {
                    _animalService.UpdateAnimal(id, animal);
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
        [SwaggerOperation(Summary = "Delete a specific animal by Id")]
        public IActionResult Delete(int id)
        {
            var animal = _animalService.GetAnimalById(id);
            if (animal != null)
            {
                _animalService.DeleteAnimal(id);
                return NoContent();
            }
            else
                return NotFound();
        }
    }
}
