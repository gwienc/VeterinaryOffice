using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    interface IVisitRepository
    {
        IQueryable<Visit> GetAll();
        Visit GetById(int id);
        Visit Add(Visit visit);
        void Update(Visit visit);
        void Delete(Visit visit);
    }
}
