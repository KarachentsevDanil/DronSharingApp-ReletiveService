using RCS.BLL.Dto.Customers;
using System.Security.Claims;

namespace RCS.WebApi.Extensions
{
    public static class UserIdentityExtensions
    {
        public static UserDto GetUserModel(this ClaimsPrincipal claims)
        {
            var user = new UserDto
            {
                UserId = claims.FindFirstValue(nameof(UserDto.UserId)),
                Role = claims.FindFirstValue(ClaimTypes.Role),
                Email = claims.FindFirstValue(ClaimTypes.Email)
            };

            if (int.TryParse(claims.FindFirstValue(nameof(UserDto.FacilityId)), out var facilityId))
            {
                user.FacilityId = facilityId;
            }

            if (int.TryParse(claims.FindFirstValue(nameof(UserDto.DoctorId)), out var doctorId))
            {
                user.DoctorId = doctorId;
            }

            return user;
        }
    }
}