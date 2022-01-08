﻿using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
