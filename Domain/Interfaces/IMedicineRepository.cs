using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
