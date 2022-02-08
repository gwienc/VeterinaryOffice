using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
            return _context.Owners.Include(x => x.Animals).ThenInclude(x => x.Prescriptions);
        }

        public Owner GetById(int id)
        {
            var owner = _context.Owners.Where(x => x.Id == id).Include(x => x.Animals).ThenInclude(x => x.Prescriptions).SingleOrDefault();
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
