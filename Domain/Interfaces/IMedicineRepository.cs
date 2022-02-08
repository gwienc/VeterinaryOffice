using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IMedicineRepository
    {
        IQueryable<Medicine> GetAll();
        Medicine GetById(int id);
        Medicine Add(Medicine medicine);
        void Update(Medicine medicine);
        void Delete(Medicine medicine);
    }
}
