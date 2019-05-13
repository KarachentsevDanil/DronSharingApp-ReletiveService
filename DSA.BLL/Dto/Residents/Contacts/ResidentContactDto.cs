using RCS.Domain.Residents;

namespace RCS.BLL.Dto.Residents
{
    public class ResidentContactDto
    {
        public int ResidentContactId { get; set; }

        public int ResidentId { get; set; }

        public string UserId { get; set; }

        public string ResidentName { get; set; }

        public string UserName { get; set; }

        public Status Status { get; set; }

        public string StatusValue { get; set; }
    }
}
