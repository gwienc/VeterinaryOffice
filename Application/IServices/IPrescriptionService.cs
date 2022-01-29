using Application.DTO.Prescription;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IPrescriptionService
    {
        IEnumerable<PrescriptionDto> GetAllPrescriptions();
        PrescriptionDto GetPrescriptionById(int id);
        PrescriptionDto AddNewPrescription(CreatePrescriptionDto newPrescription);
        void UpdatePrescription(int id, UpdatePrescriptionDto prescription);
        UpdatePrescriptionDto PartialUpdatePrescription(int id, JsonPatchDocument<UpdatePrescriptionDto> prescription);
        void DeletePrescription(int id);
    }
}
