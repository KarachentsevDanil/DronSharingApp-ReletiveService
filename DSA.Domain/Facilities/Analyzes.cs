using RCS.Domain.Facilities;
using System.Collections.Generic;

namespace RCS.Domain.Residents
{
    public class Analyzes
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string RoomNumber { get; set; }

        public int DepartmentId { get; set; }

        public Department Department { get; set; }

        public ICollection<ResidentAnalyzes> ResidentAnalyzes { get; set; }
    }
}