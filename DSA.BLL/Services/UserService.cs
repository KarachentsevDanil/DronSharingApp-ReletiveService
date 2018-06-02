using System.Collections.Generic;
using RCS.BLL.Dto.Customers;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Users;

namespace RCS.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public CollectionResult<UserDto> GetCustomers(UsersFilterParams filterParams)
        {
            var items = _unitOfWork.UserRepository.GetCustomers(filterParams);

            var result = new CollectionResult<UserDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<User>, List<UserDto>>(items.Collection)
            };

            return result;
        }

        public UserDto GetCustomerByTerm(string term)
        {
            var customer = _unitOfWork.UserRepository.GetUserByTerm(term);
            return AutoMapper.Mapper.Map<User, UserDto>(customer);
        }
    }
}
