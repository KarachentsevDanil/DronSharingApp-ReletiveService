using RCS.BLL.Dto.Customers;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IUserService
    {
        UserDto GetCustomerByTerm(string term);

        CollectionResult<UserDto> GetCustomers(UsersFilterParams filterParams);
    }
}
