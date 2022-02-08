using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IVetRepository
    {
        IQueryable<Vet> GetAll();
        Vet GetById(int id);
        Vet Add(Vet vet);
        void Update(Vet vet);
        void Delete(Vet vet);
    }
}
