using Domain.Entities;
using System.Linq;

namespace Domain.Interfaces
{
    public interface IVisitRepository
    {
        IQueryable<Visit> GetAll();
        Visit GetById(int id);
        Visit Add(Visit visit);
        void Update(Visit visit);
        void Delete(Visit visit);
    }
}
