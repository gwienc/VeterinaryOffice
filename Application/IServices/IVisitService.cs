using Application.DTO.Visit;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;

namespace Application.IServices
{
    public interface IVisitService
    {
        IEnumerable<VisitDto> GetAllVisits();
        VisitDto GetVisitById(int id);
        VisitDto AddNewVisit(CreateVisitDto newVisit);
        void UpdateVisit(int id, UpdateVisitDto visit);
        UpdateVisitDto PartialUpdateVisit(int id, JsonPatchDocument<UpdateVisitDto> visit);
        void DeleteVisit(int id);
    }
}
