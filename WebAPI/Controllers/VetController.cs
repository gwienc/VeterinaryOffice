﻿using Application.DTO.Vet;
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
            var newVet = _vetService.AddNewVet(vet);
            return CreatedAtAction(nameof(GetById), new { id = newVet.Id }, newVet);
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific vet by Id")]
        public IActionResult Update(int id, UpdateVetDto vet)
        {
            var updatedVet = _vetService.GetVetById(id);
            if (updatedVet != null)
            {
                _vetService.UpdateVet(id, vet);
                return NoContent();
            }
            return NotFound();
            
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