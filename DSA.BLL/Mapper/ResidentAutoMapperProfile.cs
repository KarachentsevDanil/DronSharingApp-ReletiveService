using AutoMapper;
using RCS.BLL.Dto.Residents;
using RCS.Domain.Residents;
using System;

namespace RCS.BLL.Mapper
{
    public class ResidentAutoMapperProfile : Profile
    {
        public ResidentAutoMapperProfile()
        {
            CreateMap<AddAppointmentDto, Appointment>()
                .ForMember(x => x.AppointmentId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.User, t => t.Ignore());

            CreateMap<AddObservationDto, Observation>()
                .ForMember(x => x.ObservationId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore());

            CreateMap<AddResidentContactDto, ResidentContact>()
                .ForMember(x => x.ResidentContactId, t => t.Ignore())
                .ForMember(x => x.Status, t => t.UseValue(Status.Pending))
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.User, t => t.Ignore());

            CreateMap<AddResidentDoctorDto, ResidentDoctor>()
                .ForMember(x => x.ResidentDoctorId, t => t.Ignore())
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.Doctor, t => t.Ignore());

            CreateMap<AddResidentDto, Resident>()
                .ForMember(x => x.Photo, t => t.MapFrom(p => Convert.FromBase64String(p.Photo)))
                .ForMember(x => x.ResidentId, t => t.Ignore())
                .ForMember(x => x.Facility, t => t.Ignore())
                .ForMember(x => x.Observations, t => t.Ignore())
                .ForMember(x => x.Contacts, t => t.Ignore())
                .ForMember(x => x.Appointments, t => t.Ignore())
                .ForMember(x => x.Doctors, t => t.Ignore());

            CreateMap<ResidentContactDto, ResidentContact>()
                .ForMember(x => x.Resident, t => t.Ignore())
                .ForMember(x => x.User, t => t.Ignore());

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(x => x.Period, t => t.MapFrom(p => $"From: {p.Date.ToShortTimeString()} during {p.Duration.ToString()} hour(s)."))
                .ForMember(x => x.DateValue, t => t.MapFrom(p => p.Date.ToShortDateString()))
                .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
                .ForMember(x => x.UserName, t => t.MapFrom(p => $"{p.User.FirstName} {p.User.LastName}"));

            CreateMap<Observation, ObservationDto>()
               .ForMember(x => x.RecordedDate, t => t.MapFrom(p => p.RecordedDate.ToString("f")))
               .ForMember(x => x.Value, t => t.MapFrom(p => Math.Round(p.Value ?? 0, 2)))
               .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
               .ForMember(x => x.TypeValue, t => t.MapFrom(p => p.Type.ToString()))
               .ForMember(x => x.OutputValue, t => t.MapFrom(p => p.Type == ObservationType.BloodPressure ? $"{p.SystolicValue} / {p.DiastolicValue}" : $"{Math.Round(p.Value ?? 0, 2)}"));

            CreateMap<ResidentContact, ResidentContactDto>()
               .ForMember(x => x.StatusValue, t => t.MapFrom(p => p.Status.ToString()))
               .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
               .ForMember(x => x.UserName, t => t.MapFrom(p => $"{p.User.FirstName} {p.User.LastName}"));

            CreateMap<ResidentDoctor, ResidentDoctorDto>()
               .ForMember(x => x.ResidentName, t => t.MapFrom(p => $"{p.Resident.FirstName} {p.Resident.LastName}"))
               .ForMember(x => x.DoctorName, t => t.MapFrom(p => $"{p.Doctor.FirstName} {p.Doctor.LastName}"));

            CreateMap<Resident, ResidentDto>()
               .ForMember(x => x.FacilityName, t => t.MapFrom(p => p.Facility.Name))
               .ForMember(x => x.FacilityCity, t => t.MapFrom(p => p.Facility.City))
               .ForMember(x => x.FacilityEmail, t => t.MapFrom(p => p.Facility.Email))
               .ForMember(x => x.FacilityPhone, t => t.MapFrom(p => p.Facility.Phone))
               .ForMember(x => x.FullName, t => t.MapFrom(p => $"{p.FirstName} {p.LastName}"))
               .ForMember(x => x.AdmissionDate, t => t.MapFrom(p => p.AdmissionDate.HasValue ? p.AdmissionDate.Value.ToShortDateString() : string.Empty))
               .ForMember(x => x.DischargeDate, t => t.MapFrom(p => p.DischargeDate.HasValue ? p.DischargeDate.Value.ToShortDateString() : string.Empty))
               .ForMember(x => x.FormattedDate, t => t.MapFrom(p => p.BirthDay.ToShortDateString()))
               .ForMember(x => x.Photo, t => t.MapFrom(p => $"data:image/png;base64,{Convert.ToBase64String(p.Photo)}"));
        }
    }
}
