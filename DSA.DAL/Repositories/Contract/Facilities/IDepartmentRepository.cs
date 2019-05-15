using System.Collections.Generic;
using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories.Contract
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        CollectionResult<Department> GetDepartmentsByParams(DepartmentsFilterParams parameters);

        IEnumerable<Department> GetDepartmentsByTerm(int facilityId, string term);
    }
}