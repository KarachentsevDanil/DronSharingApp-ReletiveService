﻿using RCS.Domain.Residents;
using RCS.Domain.Users;
using System.Collections.Generic;

namespace RCS.Domain.Facilities
{
    public class Facility
    {
        public int FacilityId { get; set; }

        public string Name { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public virtual ICollection<Department> Departments { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
