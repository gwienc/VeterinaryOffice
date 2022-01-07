using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
