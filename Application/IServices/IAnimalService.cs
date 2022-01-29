﻿using Application.DTO.Animal;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAnimalService
    {
        IEnumerable<AnimalDto> GetAllAnimals();
        AnimalDto GetAnimalById(int id);
        AnimalDto AddNewAnimal(CreateAnimalDto newAnimal);
        void UpdateAnimal(int id, UpdateAnimalDto animal);
        UpdateAnimalDto PartialUpdateAnimal(int id, JsonPatchDocument<UpdateAnimalDto> animal);
        void DeleteAnimal(int id);
    }
}
