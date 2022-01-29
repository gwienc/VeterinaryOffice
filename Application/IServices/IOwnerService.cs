using Application.DTO.Owner;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
