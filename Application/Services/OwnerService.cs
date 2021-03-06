using Application.DTO.Owner;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Application.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMapper _mapper;

        public OwnerService(IOwnerRepository ownerRepository,IAnimalRepository animalRepository, IMapper mapper)
        {
            _ownerRepository = ownerRepository;
            _animalRepository = animalRepository;
            _mapper = mapper;
        }
        public IEnumerable<OwnerDto> GetAllOwners()
        {
            var owners = _ownerRepository.GetAll();
            return _mapper.Map<IEnumerable<OwnerDto>>(owners);
        }

        public OwnerDto GetOwnerById(int id)
        {
            var owner = _ownerRepository.GetById(id);
            return _mapper.Map<OwnerDto>(owner);
        }

        public OwnerDto AddNewOwner(CreateOwnerDto newOwner)
        {                      
            var owner = _mapper.Map<Owner>(newOwner);
            _ownerRepository.Add(owner);
            
            return _mapper.Map<OwnerDto>(owner);
        }

        public void UpdateOwner(int id, UpdateOwnerDto owner)
        {
            var existingOwner = _ownerRepository.GetById(id);
            var updatedOwner = _mapper.Map(owner, existingOwner);
            
            _ownerRepository.Update(updatedOwner);
        }

        public UpdateOwnerDto PartialUpdateOwner(int id, JsonPatchDocument<UpdateOwnerDto> owner)
        {
            var existingOwner = _ownerRepository.GetById(id);
            var ownerToPatch = _mapper.Map<UpdateOwnerDto>(existingOwner);
            owner.ApplyTo(ownerToPatch);

            return ownerToPatch;
        }

        public void DeleteOwner(int id)
        {
            var owner = _ownerRepository.GetById(id);
            _ownerRepository.Delete(owner);
        }       
    }
}
