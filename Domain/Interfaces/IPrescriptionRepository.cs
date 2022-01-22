using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
