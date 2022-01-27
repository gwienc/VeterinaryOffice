using Application.DTO.Animal;
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
    public class AnimalService : IAnimalService
    {
        private readonly IAnimalRepository _animalRepository;
        private readonly IOwnerRepository _ownerRepository;
        private readonly IMapper _mapper;

        public AnimalService(IAnimalRepository animalRepository, IOwnerRepository ownerRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _ownerRepository = ownerRepository;
            _mapper = mapper;
        }
        public IEnumerable<AnimalDto> GetAllAnimals()
        {
            var animals = _animalRepository.GetAll();
            return _mapper.Map<IEnumerable<AnimalDto>>(animals);
        }

        public AnimalDto GetAnimalById(int id)
        {
            var animal = _animalRepository.GetById(id);
            return _mapper.Map<AnimalDto>(animal);
        }

        public AnimalDto AddNewAnimal(CreateAnimalDto newAnimal)
        {          
            var owner = _ownerRepository.GetById(newAnimal.OwnerId);
            if (owner == null)
            {
                    throw new Exception("This owner does not exist");
            }
            
            var animal = _mapper.Map<Animal>(newAnimal);
            _animalRepository.Add(animal);
            
            return _mapper.Map<AnimalDto>(animal);
        }

        public void UpdateAnimal(int id, UpdateAnimalDto animal)
        {
            var existingAnimal = _animalRepository.GetById(id);
            
            var owner = _ownerRepository.GetById(animal.OwnerId);
            if (owner == null)
            {
                throw new Exception("This owner does not exist");
            }

            var updatedAnimal = _mapper.Map(animal, existingAnimal);

            _animalRepository.Update(updatedAnimal);
        }

        public void DeleteAnimal(int id)
        {
            var animal = _animalRepository.GetById(id);
            _animalRepository.Delete(animal);
        }
      
    }
}
