using RCS.Domain.Users;
using System;

namespace RCS.BLL.Dto.Customers
{
    public class UserRegistrationDto
    {
        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Password { get; set; }

        public Role Role { get; set; }

        public DateTime? DateOfBirthsday { get; set; }

        public int? FacilityId { get; set; }
    }
}