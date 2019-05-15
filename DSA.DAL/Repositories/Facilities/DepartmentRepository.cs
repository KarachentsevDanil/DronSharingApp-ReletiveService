using System.Collections.Generic;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Facilities;
using RCS.Domain.Params;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public DepartmentRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Department> GetDepartmentsByParams(DepartmentsFilterParams parameters)
        {
            var appointments = GetAllDepartments();

            FillDepartmentsQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderBy(x => x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<Department>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        public IEnumerable<Department> GetDepartmentsByTerm(int facilityId, string term)
        {
            return _dbContext.Departments
                .Include(t => t.Facility)
                .Where(t => t.FacilityId == facilityId && t.Name.Contains(term))
                .AsNoTracking();
        }

        private IQueryable<Department> GetAllDepartments()
        {
            return _dbContext.Departments.Include(t => t.Facility).AsQueryable();
        }

        private void FillDepartmentsQueryParams(DepartmentsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Department>(t => t.FacilityId == filterParams.FacilityId);

            if (!string.IsNullOrWhiteSpace(filterParams.Term))
            {
                predicate = predicate.And(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }
    }
}
