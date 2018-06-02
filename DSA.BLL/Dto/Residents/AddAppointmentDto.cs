using System;

namespace RCS.BLL.Dto.Residents
{
    public class AddAppointmentDto
    {
        public int ResidentId { get; set; }

        public string UserId { get; set; }

        public DateTime Date { get; set; }

        public TimeSpan Duration { get; set; }
    }
}
