using Application.DTO.Animal;
using Application.DTO.Medicine;
using Application.DTO.Owner;
using Application.DTO.Vet;
using Application.DTO.Visit;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mappings
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize() => new MapperConfiguration(cfg =>
        {
            #region Animal

            cfg.CreateMap<Animal, AnimalDto>()
            .ForMember(m => m.Medicines, map => map.MapFrom(animal => animal.Animals_Medicines.SelectMany(n => new List<string> { n.Medicine.Name })));            
            cfg.CreateMap<CreateAnimalDto, Animal>();
            cfg.CreateMap<UpdateAnimalDto, Animal>();
            cfg.CreateMap<Animal, AnimalVisitDto>()
            .ForMember(m => m.Medicines, map => map.MapFrom(animal => animal.Animals_Medicines.SelectMany(n => new List<string> { n.Medicine.Name })));

            #endregion

            #region Medicine

            cfg.CreateMap<Medicine, MedicineDto>();
            cfg.CreateMap<CreateMedicineDto, Medicine>();
            cfg.CreateMap<UpdateMedicineDto, Medicine>();

            cfg.CreateMap<Medicine, MedicineWithAnimalsDto>()
            .ForMember(m => m.Animals, map => map.MapFrom(medicine => medicine.Animals_Medicines.SelectMany(n => new List<int> { n.AnimalId })));

            #endregion

            #region Owner

            cfg.CreateMap<Owner, OwnerDto>();
            cfg.CreateMap<CreateOwnerDto, Owner>();
            cfg.CreateMap<UpdateOwnerDto, Owner>();
            cfg.CreateMap<Owner, OwnerVisitDto>();

            #endregion

            #region Vet

            cfg.CreateMap<Vet, VetDto>();
            cfg.CreateMap<CreateVetDto, Vet>();
            cfg.CreateMap<UpdateVetDto, Vet>();

            #endregion


            #region Visit

            cfg.CreateMap<Visit, VisitDto>();
            cfg.CreateMap<CreateVisitDto, Visit>();
            cfg.CreateMap<UpdateVisitDto, Visit>();

            #endregion

        }).CreateMapper();
    }
}
