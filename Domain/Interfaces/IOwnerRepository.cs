using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IOwnerRepository
    {
        IQueryable<Owner> GetAll();
        Owner GetById(int id);
        Owner Add(Owner owner);
        void Update(Owner owner);
        void Delete(Owner owner);
    }
}
