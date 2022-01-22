using Application.DTO.Prescription;
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
        void DeletePrescription(int id);
    }
}
