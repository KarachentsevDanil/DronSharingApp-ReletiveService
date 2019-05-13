using System;

namespace RCS.BLL.Dto.Residents
{
    public class ResidentDto
    {
        public int ResidentId { get; set; }

        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FormattedDate { get; set; }

        public DateTime BirthDay { get; set; }

        public string AdmissionDate { get; set; }

        public string DischargeDate { get; set; }

        public string Photo { get; set; }

        public int DepartmentId { get; set; }

        public int FacilityId { get; set; }

        public string FacilityName { get; set; }

        public string DepartmentName { get; set; }

        public string FacilityCity { get; set; }

        public string FacilityPhone { get; set; }

        public string FacilityEmail { get; set; }

        public int Age
        {
            get
            {
                var now = DateTime.Now;

                if (BirthDay < now)
                {
                    var age = now.Year - BirthDay.Year;
                    if (BirthDay > now.AddYears(-age)) age--;
                    return age;
                }

                return 0;
            }
        }

        public int DaysToBirthday
        {
            get
            {
                DateTime today = DateTime.Today;
                DateTime next = BirthDay.AddYears(today.Year - BirthDay.Year);

                if (next < today)
                    next = next.AddYears(1);

                return (next - today).Days;
            }
        }
    }
}
