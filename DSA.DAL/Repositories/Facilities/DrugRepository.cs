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
    public class DrugRepository : Repository<Drug>, IDrugRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public DrugRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Drug> GetDrugsByParams(DrugsFilterParams parameters)
        {
            var appointments = GetAllDrugs();

            FillDrugsQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderBy(x => x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<Drug>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<Drug> GetAllDrugs()
        {
            return _dbContext.Drugs.AsQueryable();
        }

        private void FillDrugsQueryParams(DrugsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Drug>(true);

            if (!string.IsNullOrWhiteSpace(filterParams.Term))
            {
                predicate = predicate.And(t => t.Name.Contains(filterParams.Term) ||
                                               t.Description.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }

        public IEnumerable<Drug> GetDrugsByTerm(string term)
        {
            return GetAllDrugs()
                .Where(t => t.Name.Contains(term))
                .ToList();
        }
    }
}
