using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using RCS.Domain.Facilities;
using RCS.Domain.Residents;

namespace RCS.Domain.Users
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Role Role { get; set; }

        public DateTime? DateOfBirthsday { get; set; }

        public int? FacilityId { get; set; }

        public virtual Facility Facility { get; set; }

        public virtual ICollection<ResidentContact> Residents { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }

        public User()
        {
            Residents = new List<ResidentContact>();
            Appointments = new List<Appointment>();
        }
    }

    public enum Role
    {
        User,
        Admin,
        GlobalAdmin
    }
}
