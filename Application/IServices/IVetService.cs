using Application.DTO.Vet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IVetService
    {
        IEnumerable<VetDto> GetAllVets();
        VetDto GetVetById(int id);
        VetDto AddNewVet(CreateVetDto newVet);
        void UpdateVet(int id, UpdateVetDto vet);
        void DeleteVet(int id);

    }
}
