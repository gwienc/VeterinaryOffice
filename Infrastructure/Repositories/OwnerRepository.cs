using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly VeterinaryOfficeContext _context;

        public OwnerRepository(VeterinaryOfficeContext context)
        {
            _context = context;
        }
        public IQueryable<Owner> GetAll()
        {
            return _context.Owners;
        }

        public Owner GetById(int id)
        {
            var owner = _context.Owners.Find(id);
            return owner;
        }

        public Owner Add(Owner owner)
        {
            _context.Owners.Add(owner);
            _context.SaveChanges();
            return owner;
        }
        public void Update(Owner owner)
        {
            _context.Owners.Update(owner);
            _context.SaveChanges();
        }

        public void Delete(Owner owner)
        {
            _context.Owners.Remove(owner);
            _context.SaveChanges();
        }
       
    }
}
