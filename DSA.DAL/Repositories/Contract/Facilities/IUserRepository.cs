using RCS.Domain.Params;
using RCS.Domain.Users;

namespace RCS.DAL.Repositories.Contract
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByTerm(string term);

        CollectionResult<User> GetCustomers(UsersFilterParams filterParams);
    }
}
