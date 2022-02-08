using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IPrescriptionRepository
    {
        IQueryable<Prescription> GetAll();
        Prescription GetById(int id);
        Prescription Add(Prescription prescription);
        void Update(Prescription prescription);
        void Delete(Prescription prescription);
    }
}
