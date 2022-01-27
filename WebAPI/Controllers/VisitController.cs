using Application.DTO.Visit;
using Application.IServices;
using Domain.Interfaces;
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
    public class VisitController : ControllerBase
    {
        private readonly IVisitService _visitService;

        public VisitController(IVisitService visitService)
        {
            _visitService = visitService;
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Retrieves all visits")]
        public IActionResult Get()
        {
            var visits = _visitService.GetAllVisits();
            return Ok(visits);
        }

        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieves a specific visit by Id")]
        public IActionResult GetById(int id)
        {
            var visit = _visitService.GetVisitById(id);
            if (visit != null)
            {
                return Ok(visit);
            }
            return NotFound();
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add new visit")]
        public IActionResult Create(CreateVisitDto visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var newVisit = _visitService.AddNewVisit(visit);
                return CreatedAtAction(nameof(GetById), new { id = newVisit.Id }, newVisit);
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }
           
        }

        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a specific visit by Id")]
        public IActionResult Update(int id, UpdateVisitDto visit)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatingVisit = _visitService.GetVisitById(id);
                if (updatingVisit != null)
                {
                    _visitService.UpdateVisit(id, visit);
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
        [SwaggerOperation(Summary = "Delete a specific visit by Id")]
        public IActionResult Delete(int id)
        {
            var deletingVisit = _visitService.GetVisitById(id);
            if (deletingVisit != null)
            {
                _visitService.DeleteVisit(id);
                return NoContent();
            }
            return NotFound();
        }
    }
}
