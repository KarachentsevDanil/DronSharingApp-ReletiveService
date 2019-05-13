using System.Collections.Generic;
using RCS.Domain.Facilities;

namespace RCS.Domain.Residents
{
    public class Manipulation
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int DepartmentId { get; set; }

        public string RoomNumber { get; set; }

        public Department Department { get; set; }

        public ICollection<ResidentManipulation> ResidentManipulations { get; set; }
    }
}