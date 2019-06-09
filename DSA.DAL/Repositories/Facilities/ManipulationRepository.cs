using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class ManipulationRepository : Repository<Manipulation>, IManipulationRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ManipulationRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Manipulation> GetManipulationsByParams(ManipulationsFilterParams parameters)
        {
            var appointments = GetAllManipulations();

            FillManipulationsQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderBy(x => x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<Manipulation>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<Manipulation> GetAllManipulations()
        {
            return _dbContext.Manipulations.Include(t => t.Department).ThenInclude(t => t.Facility).AsQueryable();
        }

        private void FillManipulationsQueryParams(ManipulationsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Manipulation>(t => t.DepartmentId == filterParams.FacilityId);

            if (!string.IsNullOrWhiteSpace(filterParams.Term))
            {
                predicate = predicate.And(t => t.Name.Contains(filterParams.Term) ||
                                               t.Description.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }

        public IEnumerable<Manipulation> GetManipulationsByTerm(int facilityId, string term)
        {
            return GetAllManipulations()
                .Where(t => t.Department.FacilityId == facilityId && t.Name.Contains(term))
                .ToList();
        }
    }
}
