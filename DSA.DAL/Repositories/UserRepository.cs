using System.Linq;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Users;

namespace RCS.DAL.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public UserRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public CollectionResult<User> GetCustomers(UsersFilterParams filterParams)
        {
            var users = GetAllUsers();

            FillUsersQueryParams(filterParams);

            users = users.Where(filterParams.Expression);

            var totalCount = users.Count();

            var result = users
                .Skip(filterParams.Skip)
                .Take(filterParams.Take)
                .AsNoTracking()
                .ToList();

            var userResult = new CollectionResult<User>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return userResult;
        }

        private IQueryable<User> GetAllUsers()
        {
            return _dbContext.Users
                .Include(t => t.Facility)
                .AsQueryable();
        }

        private void FillUsersQueryParams(UsersFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<User>();

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.And(t => t.LastName.Contains(filterParams.Term) || t.FirstName.Contains(filterParams.Term));
            }

            if (filterParams.FacilityId.HasValue)
            {
                predicate = predicate.And(t => t.FacilityId == filterParams.FacilityId.Value);
            }

            if (filterParams.OnlyWithFacility)
            {
                predicate = predicate.And(t => t.FacilityId.HasValue);
            }

            filterParams.Expression = predicate;
        }


        public User GetUserByTerm(string term)
        {
            return GetAllUsers().FirstOrDefault(x => x.Email.ToUpper() == term.ToUpper());
        }
    }
}