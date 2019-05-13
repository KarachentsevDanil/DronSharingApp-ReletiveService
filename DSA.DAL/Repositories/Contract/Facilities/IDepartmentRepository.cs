using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories.Contract
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        CollectionResult<Department> GetDepartmentsByParams(DepartmentsFilterParams parameters);
    }
}