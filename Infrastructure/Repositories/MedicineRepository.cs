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
    public class MedicineRepository : IMedicineRepository
    {
        private readonly VeterinaryOfficeContext _context;

        public MedicineRepository(VeterinaryOfficeContext context)
        {
            _context = context;
        }
        public IQueryable<Medicine> GetAll()
        {
           return _context.Medicines;          
        }

        public Medicine GetById(int id)
        {
            var medicine = _context.Medicines.Find(id);
            return medicine;
        }

        public Medicine Add(Medicine medicine)
        {
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return medicine;
        }
        public void Update(Medicine medicine)
        {
            _context.Medicines.Update(medicine);
            _context.SaveChanges();
        }

        public void Delete(Medicine medicine)
        {
            _context.Medicines.Remove(medicine);
            _context.SaveChanges();
        }
    }
}
