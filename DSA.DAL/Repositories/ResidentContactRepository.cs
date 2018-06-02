using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Linq;

namespace RCS.DAL.Repositories
{
    public class ResidentContactRepository : Repository<ResidentContact>, IResidentContactRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ResidentContactRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<ResidentContact> GetResidentContactsByParams(ResidentContactsFilterParams filterParams)
        {
            var residents = GetAllResidentContacts();

            FillResidentContactQueryParams(filterParams);

            residents = residents.Where(filterParams.Expression);

            var totalCount = residents.Count();

            var result = residents
                .Skip(filterParams.Skip)
                .Take(filterParams.Take)
                .AsNoTracking()
                .ToList();

            var residentResult = new CollectionResult<ResidentContact>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return residentResult;
        }

        private IQueryable<ResidentContact> GetAllResidentContacts()
        {
            return _dbContext.ResidentContacts
                .Include(t => t.Resident)
                .Include(t => t.User)
                .AsQueryable();
        }

        private void FillResidentContactQueryParams(ResidentContactsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<ResidentContact>();

            if (!string.IsNullOrEmpty(filterParams.UserId))
            {
                predicate = predicate.And(t => t.UserId == filterParams.UserId);
            }

            if (filterParams.FacilityId.HasValue)
            {
                predicate = predicate.And(t => t.Resident.FacilityId == filterParams.FacilityId);
            }

            filterParams.Expression = predicate;
        }
    }
}
