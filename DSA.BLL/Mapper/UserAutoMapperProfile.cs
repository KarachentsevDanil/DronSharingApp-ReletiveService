using AutoMapper;
using RCS.BLL.Dto.Customers;
using RCS.Domain.Users;

namespace RCS.BLL.Mapper
{
    public class UserAutoMapperProfile : Profile
    {
        public UserAutoMapperProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.UserId, t => t.MapFrom(p => p.Id))
                .ForMember(x => x.Role, t => t.MapFrom(p => p.Role.ToString()))
                .ForMember(x => x.FacilityName, t => t.MapFrom(p => p.Facility != null ? p.Facility.Name : string.Empty));
        }
    }
}
