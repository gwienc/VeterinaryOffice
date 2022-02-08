using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class VetRepository : IVetRepository
    {
        private readonly VeterinaryOfficeContext _context;

        public VetRepository(VeterinaryOfficeContext context )
        {
            _context = context;
        }

        public IQueryable<Vet> GetAll()
        {
            return _context.Vets;
        }
        public Vet GetById(int id)
        {
            var vet = _context.Vets.Find(id);
            return vet;
        }
        public Vet Add(Vet vet)
        {
            _context.Vets.Add(vet);
            _context.SaveChanges();
            return vet;
        }
        public void Update(Vet vet)
        {
            _context.Vets.Update(vet);
            _context.SaveChanges();
        }
        public void Delete(Vet vet)
        {
            _context.Vets.Remove(vet);
            _context.SaveChanges();
        }
    }
}
