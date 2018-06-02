namespace RCS.BLL.Dto.Customers
{
    public class UserDto
    {
        public string UserId { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Role { get; set; }

        public int? FacilityId { get; set; }

        public string FacilityName { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
