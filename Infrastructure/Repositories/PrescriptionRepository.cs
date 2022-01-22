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
    public class PrescriptionRepository : IPrescriptionRepository
    {
        private readonly VeterinaryOfficeContext _context;

        public PrescriptionRepository(VeterinaryOfficeContext context)
        {
            _context = context;
        }
        public IQueryable<Prescription> GetAll()
        {
            return _context.Prescriptions;
        }

        public Prescription GetById(int id)
        {
            var prescription = _context.Prescriptions.SingleOrDefault(x => x.Id == id);
            return prescription;
        }
        public Prescription Add(Prescription prescription)
        {
            _context.Prescriptions.Add(prescription);
            _context.SaveChanges();
            return prescription;
        }
        public void Update(Prescription prescription)
        {
            _context.Prescriptions.Update(prescription);
            _context.SaveChanges();
        }
        public void Delete(Prescription prescription)
        {
            _context.Remove(prescription);
            _context.SaveChanges();
        }       
  
    }
}
