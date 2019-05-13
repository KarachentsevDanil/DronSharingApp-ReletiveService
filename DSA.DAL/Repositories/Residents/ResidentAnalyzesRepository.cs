using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class ResidentAnalyzesRepository : Repository<ResidentAnalyzes>, IResidentAnalyzesRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentAnalyzesRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<ResidentAnalyzes> GetResidentAnalyzesByParams(ResidentAnalyzesFilterParams parameters)
        {
            var appointments = GetAllResidentAnalyzes();

            FillResidentAnalyzesQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderByDescending(x => x.Date)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<ResidentAnalyzes>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<ResidentAnalyzes> GetAllResidentAnalyzes()
        {
            return _dbContext.ResidentAnalyzes
                .Include(t => t.Analyzes)
                .Include(t => t.Doctor).AsQueryable();
        }

        private void FillResidentAnalyzesQueryParams(ResidentAnalyzesFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<ResidentAnalyzes>(t => t.ResidentId == filterParams.ResidentId);

            filterParams.Expression = predicate;
        }
    }
}
