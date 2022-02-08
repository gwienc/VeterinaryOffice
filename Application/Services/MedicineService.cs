using Application.DTO.Medicine;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Application.Services
{
    public class MedicineService : IMedicineService
    {
        private readonly IMedicineRepository _medicineRepository;
        private readonly IMapper _mapper;

        public MedicineService(IMedicineRepository medicineRepository, IMapper mapper )
        {
            _medicineRepository = medicineRepository;
            _mapper = mapper;
        }
        public IEnumerable<MedicineDto> GetAllMedicines()
        {
            var medicines = _medicineRepository.GetAll();
            return _mapper.Map<IEnumerable<MedicineDto>>(medicines);
        }
        public IEnumerable<MedicineWithAnimalsDto> GetAllMedicinesWithAnimals()
        {
            var medicinesWithAnimals = _medicineRepository.GetAll();
            return _mapper.Map<IEnumerable<MedicineWithAnimalsDto>>(medicinesWithAnimals);
        }
        public MedicineDto GetMedicineById(int id)
        {
            var medicine = _medicineRepository.GetById(id);
            return _mapper.Map<MedicineDto>(medicine);
        }
        public MedicineWithAnimalsDto GetMedicineWithAnimalsById(int id)
        {
            var medicineWithAnimals = _medicineRepository.GetById(id);
            return _mapper.Map<MedicineWithAnimalsDto>(medicineWithAnimals);
        }
        public MedicineDto AddNewMedicine(CreateMedicineDto newMedicine)
        {
            var medicine = _mapper.Map<Medicine>(newMedicine);
            _medicineRepository.Add(medicine);
            return _mapper.Map<MedicineDto>(medicine);
        }

        public void UpdateMedicine(int id, UpdateMedicineDto medicine)
        {
            var existingMedicine = _medicineRepository.GetById(id);
            var updatedMedicine = _mapper.Map(medicine, existingMedicine);
            _medicineRepository.Update(updatedMedicine);
        }

        public UpdateMedicineDto PartialUpdateMedicine(int id, JsonPatchDocument<UpdateMedicineDto> medicine)
        {
            var existingMedicine = _medicineRepository.GetById(id);
            var medicineToPatch = _mapper.Map<UpdateMedicineDto>(existingMedicine);
            medicine.ApplyTo(medicineToPatch);

            return medicineToPatch;
        }

        public void DeleteMedicine(int id)
        {
            var medicine = _medicineRepository.GetById(id);
            _medicineRepository.Delete(medicine);
        }
        
    }
}
