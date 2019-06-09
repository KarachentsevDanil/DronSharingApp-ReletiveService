using System;

namespace RCS.WebApi.Models
{
    public class TimelineDto
    {
        public int Type { get; set; }

        public DateTime EventDate { get; set; }

        public object Item { get; set; }
    }

    public enum TimelineType
    {
        Analyze = 1,
        Drug = 2,
        Manipulation = 3,
        Appointment = 4
    }
}