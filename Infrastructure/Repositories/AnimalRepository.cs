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
    public class AnimalRepository : IAnimalRepository
    {
        private readonly VeterinaryOfficeContext _context;

        public AnimalRepository(VeterinaryOfficeContext context)
        {
            _context = context;
        }
        public IQueryable<Animal> GetAll()
        {
            return _context.Animals.Include(x => x.Owner).Include(x => x.Owner.Animals);
        }

        public Animal GetById(int id)
        {
            var animal = _context.Animals.Include(x => x.Owner).Include(x => x.Owner.Animals).SingleOrDefault(x => x.Id == id);
            return animal;
        }

        public Animal Add(Animal animal)
        {
            _context.Animals.Add(animal);
            _context.SaveChanges();
            return animal;
        }

        public void Update(Animal animal)
        {
            _context.Animals.Update(animal);
            _context.SaveChanges();
        }

        public void Delete(Animal animal)
        {
            _context.Animals.Remove(animal);
            _context.SaveChanges();
        }       
    }
}
