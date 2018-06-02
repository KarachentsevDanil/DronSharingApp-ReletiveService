using System.Linq;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.DAL.Repositories
{
    public class ResidentRepository : Repository<Resident>, IResidentRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Resident> GetResidents(string term)
        {
            return _dbContext.Residents
                .Where(t => t.FirstName.Contains(term) || t.LastName.Contains(term))
                .OrderBy(t => t.LastName).ToList(); ;
        }

        public CollectionResult<Resident> GetResidentsByParams(ResidentsFilterParams filterParams)
        {
            var residents = GetAllResidents();

            FillResidentQueryParams(filterParams);

            residents = residents.Where(filterParams.Expression);

            var totalCount = residents.Count();

            var result = residents
                .Skip(filterParams.Skip)
                .Take(filterParams.Take)
                .AsNoTracking()
                .ToList();

            var residentResult = new CollectionResult<Resident>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return residentResult;
        }

        private IQueryable<Resident> GetAllResidents()
        {
            return _dbContext.Residents
                .Include(t => t.Facility)
                .AsQueryable();
        }

        private void FillResidentQueryParams(ResidentsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<Resident>();

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.And(t => t.LastName.Contains(filterParams.Term) || t.FirstName.Contains(filterParams.Term));
            }

            if (filterParams.FacilityId.HasValue)
            {
                predicate = predicate.And(t => t.FacilityId == filterParams.FacilityId.Value);
            }

            filterParams.Expression = predicate;
        }

        public Resident GetResidentById(int residentId)
        {
            return GetAllResidents().FirstOrDefault(t => t.ResidentId == residentId);
        }
    }
}
