using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class VisitRepository : IVisitRepository
    {
        private readonly VeterinaryOfficeContext _context;

        public VisitRepository(VeterinaryOfficeContext context)
        {
            _context = context;
        }
        public IQueryable<Visit> GetAll()
        {
            return _context.Visits.Include(x => x.Animal).Include(x => x.Vet).Include(x => x.Animal.Owner);
        }

        public Visit GetById(int id)
        {
            var visit = _context.Visits.Where(x => x.Id == id).Include(x => x.Animal).Include(x => x.Vet).Include(x => x.Animal.Owner).SingleOrDefault();
            return visit;
        }

        public Visit Add(Visit visit)
        {
            _context.Visits.Add(visit);
            _context.SaveChanges();
            return visit;
        }
        public void Update(Visit visit)
        {
            _context.Visits.Update(visit);
            _context.SaveChanges();
        }
        public void Delete(Visit visit)
        {
            _context.Visits.Remove(visit);
            _context.SaveChanges();
        }       
    }
}
