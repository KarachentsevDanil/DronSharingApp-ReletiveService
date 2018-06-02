using System;

namespace RCS.BLL.Dto.Residents
{
    public class AppointmentDto
    {
        public int AppointmentId { get; set; }

        public int ResidentId { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public string DateValue { get; set; }

        public TimeSpan Duration { get; set; }

        public string Period { get; set; }

        public string ResidentName { get; set; }

        public string UserName { get; set; }
    }
}
