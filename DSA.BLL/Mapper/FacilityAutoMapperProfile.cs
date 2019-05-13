using AutoMapper;
using RCS.BLL.Dto.Facilities;
using RCS.Domain.Facilities;
using System;
using RCS.Domain.Residents;

namespace RCS.BLL.Mapper
{
    public class FacilityAutoMapperProfile : Profile
    {
        public FacilityAutoMapperProfile()
        {
            CreateMap<AddDoctorDto, Doctor>()
                .ForMember(x => x.Photo, t => t.MapFrom(p => Convert.FromBase64String(p.Photo)));

            CreateMap<AddDoctorSpecializationDto, DoctorSpecialization>()
                .ForMember(x => x.DoctorSpecializationId, t => t.Ignore())
                .ForMember(x => x.Doctors, t => t.Ignore());

            CreateMap<AddFacilityDto, Facility>()
                .ForMember(x => x.FacilityId, t => t.Ignore());

            CreateMap<Doctor, DoctorDto>()
                .ForMember(x => x.FullName, t => t.MapFrom(p => $"{p.FirstName} {p.LastName}"))
                .ForMember(x => x.Photo, t => t.MapFrom(p => $"data:image/png;base64,{Convert.ToBase64String(p.Photo)}"))
                .ForMember(x => x.BirthDate, t => t.MapFrom(p => p.BirthDate.HasValue ? p.BirthDate.Value.ToShortDateString() : string.Empty))
                .ForMember(x => x.Specialization, t => t.MapFrom(p => p.DoctorSpecialization.Name))
                .ForMember(x => x.DepartmentName, t => t.MapFrom(p => p.Department.Name))
                .ForMember(x => x.FacilityName, t => t.MapFrom(p => p.Department.Facility.Name));

            CreateMap<DoctorSpecialization, DoctorSpecializationDto>();

            CreateMap<Facility, FacilityDto>();

            CreateMap<AddDrugDto, Drug>();

            CreateMap<Drug, DrugDto>();

            CreateMap<AddDepartmentDto, Department>();

            CreateMap<Department, DepartmentDto>()
                .ForMember(x => x.FacilityName, t => t.MapFrom(p => p.Facility.Name));

            CreateMap<AddAnalyzesDto, Analyzes>();

            CreateMap<Analyzes, AnalyzesDto>()
                .ForMember(x => x.DepartmentName, t => t.MapFrom(p => p.Department.Name));

            CreateMap<AddManipulationDto, Manipulation>();

            CreateMap<Manipulation, ManipulationDto>()
                .ForMember(x => x.DepartmentName, t => t.MapFrom(p => p.Department.Name));
        }
    }
}
