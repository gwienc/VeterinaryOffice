using Domain.Entities;
using System.Linq;

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
