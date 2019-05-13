using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class ResidentManipulationRepository : Repository<ResidentManipulation>, IResidentManipulationRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentManipulationRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<ResidentManipulation> GetResidentManipulationsByParams(ResidentManipulationsFilterParams parameters)
        {
            var appointments = GetAllResidentManipulations();

            FillResidentManipulationsQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderByDescending(x => x.Date)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<ResidentManipulation>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<ResidentManipulation> GetAllResidentManipulations()
        {
            return _dbContext.ResidentManipulations
                .Include(t => t.Manipulation)
                .Include(t => t.Doctor).AsQueryable();
        }

        private void FillResidentManipulationsQueryParams(ResidentManipulationsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<ResidentManipulation>(t => t.ResidentId == filterParams.ResidentId);

            filterParams.Expression = predicate;
        }
    }
}