using Application.DTO.Owner;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IOwnerService
    {
        IEnumerable<OwnerDto> GetAllOwners();
        OwnerDto GetOwnerById(int id);
        OwnerDto AddNewOwner(CreateOwnerDto newOwner);
        void UpdateOwner(int id, UpdateOwnerDto owner);
        UpdateOwnerDto PartialUpdateOwner(int id, JsonPatchDocument<UpdateOwnerDto> owner);
        void DeleteOwner(int id);
    }
}
