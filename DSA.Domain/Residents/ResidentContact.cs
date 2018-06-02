using RCS.Domain.Users;

namespace RCS.Domain.Residents
{
    public class ResidentContact
    {
        public int ResidentContactId { get; set; }

        public int ResidentId { get; set; }

        public string UserId { get; set; }

        public Status Status { get; set; }

        public virtual Resident Resident { get; set; }

        public virtual User User { get; set; }
    }

    public enum Status
    {
        Pending = 0,
        Approved = 1,
        Canceled = 2
    }
}
