using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class ResidentDrugRepository : Repository<ResidentDrug>, IResidentDrugRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentDrugRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<ResidentDrug> GetResidentDrugsByParams(ResidentDrugsFilterParams parameters)
        {
            var appointments = GetAllResidentDrugs();

            FillResidentDrugsQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderByDescending(x => x.EndDate)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<ResidentDrug>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<ResidentDrug> GetAllResidentDrugs()
        {
            return _dbContext.ResidentDrugs
                .Include(t => t.Drug)
                .Include(t => t.Doctor).AsQueryable();
        }

        private void FillResidentDrugsQueryParams(ResidentDrugsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<ResidentDrug>(t => t.ResidentId == filterParams.ResidentId);

            filterParams.Expression = predicate;
        }
    }
}