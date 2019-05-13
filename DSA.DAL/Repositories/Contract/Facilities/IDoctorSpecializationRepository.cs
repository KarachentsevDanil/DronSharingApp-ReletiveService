using System.Collections.Generic;
using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories.Contract
{
    public interface IDoctorSpecializationRepository : IRepository<DoctorSpecialization>
    {
        IEnumerable<DoctorSpecialization> GetDoctorSpecializations(string term);

        CollectionResult<DoctorSpecialization> GetDoctorSpecializationsByParams(DoctorSpecializationsFilterParams parameters);
    }
}
