using Application.DTO.Prescription;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

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
