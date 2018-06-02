using System.Collections.Generic;
using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories.Contract
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetDoctors(string term);

        CollectionResult<Doctor> GetDoctorsByParams(DoctorsFilterParams parameters);
    }
}
