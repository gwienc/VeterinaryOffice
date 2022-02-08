using Application.DTO.Vet;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IVetService
    {
        IEnumerable<VetDto> GetAllVets();
        VetDto GetVetById(int id);
        VetDto AddNewVet(CreateVetDto newVet);
        void UpdateVet(int id, UpdateVetDto vet);
        UpdateVetDto PartialUpdateVet(int id, JsonPatchDocument<UpdateVetDto> vet);
        void DeleteVet(int id);

    }
}
