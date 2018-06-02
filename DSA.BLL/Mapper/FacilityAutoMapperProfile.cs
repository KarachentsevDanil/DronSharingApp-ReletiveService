using AutoMapper;
using RCS.BLL.Dto.Facilities;
using RCS.Domain.Facilities;

namespace RCS.BLL.Mapper
{
    public class FacilityAutoMapperProfile : Profile
    {
        public FacilityAutoMapperProfile()
        {
            CreateMap<AddDoctorDto, Doctor>()
                .ForMember(x => x.DoctorId, t => t.Ignore())
                .ForMember(x => x.DoctorSpecialization, t => t.Ignore())
                .ForMember(x => x.Facility, t => t.Ignore())
                .ForMember(x => x.Residents, t => t.Ignore());

            CreateMap<AddDoctorSpecializationDto, DoctorSpecialization>()
                .ForMember(x => x.DoctorSpecializationId, t => t.Ignore())
                .ForMember(x => x.Doctors, t => t.Ignore());

            CreateMap<AddFacilityDto, Facility>()
                .ForMember(x => x.FacilityId, t => t.Ignore())
                .ForMember(x => x.Residents, t => t.Ignore())
                .ForMember(x => x.Users, t => t.Ignore())
                .ForMember(x => x.Doctors, t => t.Ignore());

            CreateMap<Doctor, DoctorDto>()
                .ForMember(x => x.FullName, t => t.MapFrom(p => $"{p.FirstName} {p.LastName}"))
                .ForMember(x => x.Specialization, t => t.MapFrom(p => p.DoctorSpecialization.Name))
                .ForMember(x => x.FacilityName, t => t.MapFrom(p => p.Facility.Name));

            CreateMap<DoctorSpecialization, DoctorSpecializationDto>();

            CreateMap<Facility, FacilityDto>();
        }
    }
}
