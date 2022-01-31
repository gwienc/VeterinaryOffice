using Application.DTO.Vet;
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
    public class VetService : IVetService
    {
        private readonly IVetRepository _vetRepository;
        private readonly IMapper _mapper;

        public VetService(IVetRepository vetRepository, IMapper mapper)
        {
            _vetRepository = vetRepository;
            _mapper = mapper;
        }
        public IEnumerable<VetDto> GetAllVets()
        {
            var vets = _vetRepository.GetAll();
            return _mapper.Map<IEnumerable<VetDto>>(vets);
        }

        public VetDto GetVetById(int id)
        {
            var vet = _vetRepository.GetById(id);
            return _mapper.Map<VetDto>(vet);
        }

        public VetDto AddNewVet(CreateVetDto newVet)
        {          
            var vet = _mapper.Map<Vet>(newVet);
            _vetRepository.Add(vet);

            return _mapper.Map<VetDto>(vet);
        }

        public void UpdateVet(int id, UpdateVetDto vet)
        {
            var existingVet = _vetRepository.GetById(id);
            var updatedVet = _mapper.Map(vet, existingVet);

            _vetRepository.Update(updatedVet);
        }
        public UpdateVetDto PartialUpdateVet(int id, JsonPatchDocument<UpdateVetDto> vet)
        {
            var existingVet = _vetRepository.GetById(id);
            var vetToPatch = _mapper.Map<UpdateVetDto>(existingVet);
            vet.ApplyTo(vetToPatch);

            return vetToPatch;
        }
        public void DeleteVet(int id)
        {
            var vet = _vetRepository.GetById(id);
            _vetRepository.Delete(vet);
        }       
    }
}
