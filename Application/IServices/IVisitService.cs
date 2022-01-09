using Application.DTO.Visit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IVisitService
    {
        IEnumerable<VisitDto> GetAllVisits();
        VisitDto GetVisitById(int id);
        VisitDto AddNewVisit(CreateVisitDto newVisit);
        void UpdateVisit(int id, UpdateVisitDto visit);
        void DeleteVisit(int id);
    }
}
