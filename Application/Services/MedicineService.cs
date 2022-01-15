using Application.DTO.Medicine;
using Application.IServices;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public MedicineDto GetMedicineById(int id)
        {
            var medicine = _medicineRepository.GetById(id);
            return _mapper.Map<MedicineDto>(medicine);
        }

        public MedicineDto AddNewMedicine(CreateMedicineDto newMedicine)
        {
            if (string.IsNullOrEmpty(newMedicine.Name))
            {
                throw new Exception("Medicine can not has empty name");
            }

            var medicine = _mapper.Map<Medicine>(newMedicine);
            _medicineRepository.Add(medicine);
            return _mapper.Map<MedicineDto>(medicine);
        }

        public void UpdateMedicine(int id, UpdateMedicineDto medicine)
        {
            if (string.IsNullOrEmpty(medicine.Name))
            {
                throw new Exception("Medicine can not has empty name");
            }

            var existingMedicine = _medicineRepository.GetById(id);
            var updatedMedicine = _mapper.Map(medicine, existingMedicine);
            _medicineRepository.Update(updatedMedicine);
        }

        public void DeleteMedicine(int id)
        {
            var medicine = _medicineRepository.GetById(id);
            _medicineRepository.Delete(medicine);
        }

        public IEnumerable<MedicineWithAnimalsDto> GetAllMedicinesWithAnimals()
        {
            throw new NotImplementedException();
        }

        public MedicineWithAnimalsDto GetMedicineWithAnimalsById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
