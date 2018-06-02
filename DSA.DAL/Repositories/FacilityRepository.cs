using System.Linq;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Facilities;
using System.Collections.Generic;

namespace RCS.DAL.Repositories
{
    public class FacilityRepository : Repository<Facility>, IFacilityRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public FacilityRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        private IQueryable<Facility> GetAllFacilities()
        {
            return _dbContext.Facilities
                .AsQueryable();
        }

        private void FillFacilitiesQueryParams(FacilitiesFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<Facility>();

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.And(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }

        public CollectionResult<Facility> GetFacilitiesByParams(FacilitiesFilterParams filterParams)
        {
            var facilities = GetAllFacilities();

            FillFacilitiesQueryParams(filterParams);

            facilities = facilities.Where(filterParams.Expression);

            var totalCount = facilities.Count();

            var result = facilities
                .Skip(filterParams.Skip)
                .Take(filterParams.Take)
                .AsNoTracking()
                .ToList();

            var airTaxiResult = new CollectionResult<Facility>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return airTaxiResult;
        }

        public IEnumerable<Facility> GetFacilitiesByTerm(string term)
        {
            return GetAllFacilities().Where(t => t.Name.Contains(term)).ToList();
        }
    }
}
