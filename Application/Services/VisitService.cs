using Application.DTO.Visit;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class VisitService : IVisitService
    {
        private readonly IVisitRepository _visitRepository;
        private readonly IVetRepository _vetRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public VisitService(IVisitRepository visitRepository, IVetRepository vetRepository, IAnimalRepository animalRepository, IMapper mapper)
        {
            _visitRepository = visitRepository;
            _vetRepository = vetRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }
        public IEnumerable<VisitDto> GetAllVisits()
        {
            var visits = _visitRepository.GetAll();
            return _mapper.Map<IEnumerable<VisitDto>>(visits);
        }

        public VisitDto GetVisitById(int id)
        {
            var visit = _visitRepository.GetById(id);
            return _mapper.Map<VisitDto>(visit);
        }

        public VisitDto AddNewVisit(CreateVisitDto newVisit)
        {          
            var animal = _animalRepository.GetById(newVisit.AnimalId);
            if (animal == null)
            {
                throw new Exception("This animal does not exist");
            }

            var vet = _vetRepository.GetById(newVisit.VetId);
            if (vet == null)
            {
                throw new Exception("This Vet does not exist");
            }

            var visit = _mapper.Map<Visit>(newVisit);
            
            visit.LastModifiedVisit = DateTime.Now;
            visit.RegistrationDate = DateTime.Now;
            
            _visitRepository.Add(visit);

            return _mapper.Map<VisitDto>(visit);
        }

        public void UpdateVisit(int id, UpdateVisitDto visit)
        {
            var animal = _animalRepository.GetById(visit.AnimalId);
            if (animal == null)
            {
                throw new Exception("This animal does not exist");
            }

            var vet = _vetRepository.GetById(visit.VetId);
            if (vet == null)
            {
                throw new Exception("This Vet does not exist");
            }

            var existingVisit = _visitRepository.GetById(id);           
            var updatedVisit = _mapper.Map(visit, existingVisit);
            updatedVisit.LastModifiedVisit = DateTime.Now;

            _visitRepository.Update(updatedVisit);
        }
        public UpdateVisitDto PartialUpdateVisit(int id, JsonPatchDocument<UpdateVisitDto> visit)
        {
            var existingVisit = _visitRepository.GetById(id);
            var visitToPatch = _mapper.Map<UpdateVisitDto>(existingVisit);
            visit.ApplyTo(visitToPatch);
            
            return visitToPatch;
        }
        public void DeleteVisit(int id)
        {
            var visit = _visitRepository.GetById(id);
            _visitRepository.Delete(visit);
        }       
    }
}
