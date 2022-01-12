using Application.DTO.Visit;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
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
            if (string.IsNullOrEmpty(newVisit.VisitType))
            {
                throw new Exception("Visit can not has empty type of visit");
            }

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
            
            visit.LastModifiedVisit = DateTime.UtcNow;
            visit.RegistrationDate = DateTime.UtcNow;
            
            _visitRepository.Add(visit);

            return _mapper.Map<VisitDto>(visit);
        }

        public void UpdateVisit(int id, UpdateVisitDto visit)
        {
            if (string.IsNullOrEmpty(visit.VisitType))
            {
                throw new Exception("Visit can not has empty type of visit");
            }

            var existingVisit = _visitRepository.GetById(id);           
            var updatedVisit = _mapper.Map(visit, existingVisit);
            updatedVisit.LastModifiedVisit = DateTime.UtcNow;

            _visitRepository.Update(updatedVisit);
        }

        public void DeleteVisit(int id)
        {
            var visit = _visitRepository.GetById(id);
            _visitRepository.Delete(visit);
        }

    }
}
