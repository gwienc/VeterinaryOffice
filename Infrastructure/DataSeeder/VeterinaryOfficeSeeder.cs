using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.DataSeeder
{
    public class VeterinaryOfficeSeeder
    {
        private readonly VeterinaryOfficeContext _context;

        public VeterinaryOfficeSeeder(VeterinaryOfficeContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Database.CanConnect())
            {
                if (DatabaseIsEmpty() == true)
                {
                    InsertSampleData();
                }
            }
        }       

        private bool DatabaseIsEmpty()
        {
            if (!_context.Animals.Any() && !_context.Medicines.Any() && !_context.Owners.Any() && !_context.Prescriptions.Any() && !_context.Vets.Any() && !_context.Visits.Any())
            {
                return true;
            }
            return false;
        }

        private void InsertSampleData()
        {
            var medicines = new List<Medicine>
            {
                new Medicine
                {

                    Name = "Szczepionka"
                },
                new Medicine
                {

                    Name = "Krople"
                },
                new Medicine
                {

                    Name = "Witaminy"
                }
            };
            var prescriptions = new List<Prescription>
            {
                new Prescription
                {

                    PrescriptionDate = DateTime.Now,
                    ValidityPeriod = DateTime.Now.AddDays(10),
                    Medicine = medicines[1]
                },
                new Prescription
                {

                    PrescriptionDate = DateTime.Now,
                    ValidityPeriod = DateTime.Now.AddDays(10),
                    Medicine = medicines[2]
                }
            };
            var vets = new List<Vet>
            {
                new Vet
                {

                    FirstName = "Adam",
                    LastName = "Kowal"
                },
                new Vet
                {

                    FirstName = "Jan",
                    LastName = "Kowalski"
                },
                new Vet
                {
                    
                    FirstName = "Tomasz",
                    LastName = "Nowak"
                }
            };
            var owners = new List<Owner>
            {
                new Owner
                {
                    FirstName = "Łukasz",
                    LastName = "Nowicki",
                    Street = "Słoneczna",
                    PostCode = "44-660",
                    City = "Rzeszów",
                },
                new Owner
                {
                    FirstName = "Mariusz",
                    LastName = "Sawicki",
                    Street = "Brzozowa",
                    PostCode = "64-565",
                    City = "Poznań"
                }
            };
            var animals = new List<Animal>
            {
                new Animal
                {

                    AnimalType = "Pies",
                    Name = "Rex",
                    Breed = "Owczarek",
                    Age = 3,
                    Weight = 15,
                    Gender = "Samiec",
                    Owner = owners[0],
                    Prescriptions = new List<Prescription>()
                    {
                        prescriptions[0]
                    }
                },
                new Animal
                {

                    AnimalType = "Pies",
                    Name = "Azor",
                    Breed = "Kundel",
                    Age = 6,
                    Weight = 5,
                    Gender = "Samiec",
                    Owner = owners[1]                   
                },
                new Animal
                {

                    AnimalType = "Kot",
                    Name = "Mruczek",
                    Breed = "Maine Coon",
                    Age = 4,
                    Weight = 7,
                    Gender = "Kocica",
                    Owner = owners[1],
                    Prescriptions = new List<Prescription>()
                    {
                        prescriptions[1]
                    }

                }
            };          
            var visits = new List<Visit>
            {
                new Visit
                {
                    
                    VisitType = "Wizyta okresowa",
                    Description = "Przegląd",
                    VisitDate = DateTime.Now,
                    LastModifiedVisit = DateTime.Now,
                    Animal = animals[0],                                                                                   
                    Vet = vets[0]
                },
                new Visit
                {
                    
                    VisitType = "Szczepienie",
                    Description = "Coroczne szczepienie przeciw wściekliźnie",
                    VisitDate = DateTime.Now.AddDays(5),
                    LastModifiedVisit = DateTime.Now,
                    Animal = animals[2],
                    Vet = vets[1]
                }                
            };

            _context.AddRange(vets);           
            _context.AddRange(medicines);
            _context.AddRange(owners);
            _context.AddRange(animals);
            _context.AddRange(prescriptions);
            _context.AddRange(visits);
            _context.SaveChanges();
        }
    }
}
