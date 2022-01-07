using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IAnimalRepository
    {
        IQueryable<Animal> GetAll();
        Animal GetById(int id);
        Animal Add(Animal animal);
        void Update(Animal animal);
        void Delete(Animal animal);
    }
}
