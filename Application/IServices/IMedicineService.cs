﻿using Application.DTO.Medicine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IMedicineService
    {
        IEnumerable<MedicineDto> GetAllMedicines();
        IEnumerable<MedicineWithAnimalsDto> GetAllMedicinesWithAnimals();
        MedicineDto GetMedicineById(int id);
        MedicineWithAnimalsDto GetMedicineWithAnimalsById(int id);
        MedicineDto AddNewMedicine(CreateMedicineDto newMedicine);
        void UpdateMedicine(int id, UpdateMedicineDto medicine);
        void DeleteMedicine(int id);
    }
}