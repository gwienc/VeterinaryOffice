using Application.DTO.Prescription;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class PrescriptionService : IPrescriptionService
    {
        private readonly IPrescriptionRepository _prescriptionRepository;
        private readonly IMapper _mapper;
        private readonly IAnimalRepository _animalRepository;
        private readonly IMedicineRepository _medicineRepository;

        public PrescriptionService(IPrescriptionRepository prescriptionRepository, IMapper mapper, IAnimalRepository animalRepository, IMedicineRepository medicineRepository)
        {
            _prescriptionRepository = prescriptionRepository;
            _mapper = mapper;
            _animalRepository = animalRepository;
            _medicineRepository = medicineRepository;
        }
        public IEnumerable<PrescriptionDto> GetAllPrescriptions()
        {
            var prescriptions = _prescriptionRepository.GetAll().ToList();
            return _mapper.Map<IEnumerable<PrescriptionDto>>(prescriptions);
        }

        public PrescriptionDto GetPrescriptionById(int id)
        {
            var prescription = _prescriptionRepository.GetById(id);
            return _mapper.Map<PrescriptionDto>(prescription);
        }
        public PrescriptionDto AddNewPrescription(CreatePrescriptionDto newPrescription)
        {
            if (newPrescription.MedicineId == 0 || newPrescription.AnimalId == 0 )
            {
                throw new Exception("Animal ID and Medicine ID are required and cannot be 0");
            }

            var animal = _animalRepository.GetById(newPrescription.AnimalId);
            if (animal == null)
            {
                throw new Exception("This animal does not exist");
            }

            var medicine = _medicineRepository.GetById(newPrescription.MedicineId);
            if (medicine == null)
            {
                throw new Exception("This medicine does not exist");
            }

            var prescription = _mapper.Map<Prescription>(newPrescription);
            prescription.PrescriptionDate = DateTime.Now;
            
            _prescriptionRepository.Add(prescription);
            
            return _mapper.Map<PrescriptionDto>(prescription);
        }
        public void UpdatePrescription(int id, UpdatePrescriptionDto prescription)
        {           
            var animal = _animalRepository.GetById(prescription.AnimalId);
            if (animal == null)
            {
                throw new Exception("This animal does not exist");
            }
            
            var medicine = _medicineRepository.GetById(prescription.MedicineId);
            if (medicine == null)
            {
                throw new Exception("This medicine does not exist");
            }
            
            var existingPrescription = _prescriptionRepository.GetById(id);
            var updatingPrescription = _mapper.Map(prescription, existingPrescription);
            
            _prescriptionRepository.Update(updatingPrescription);
            
        }
        public UpdatePrescriptionDto PartialUpdatePrescription(int id, JsonPatchDocument<UpdatePrescriptionDto> prescription)
        {
            var existingPrescription = _prescriptionRepository.GetById(id);
            var prescriptionToPatch = _mapper.Map<UpdatePrescriptionDto>(existingPrescription);
            prescription.ApplyTo(prescriptionToPatch);

            return prescriptionToPatch;
        }
        public void DeletePrescription(int id)
        {
            var prescription = _prescriptionRepository.GetById(id);
            _prescriptionRepository.Delete(prescription);
        }       
    }
}
