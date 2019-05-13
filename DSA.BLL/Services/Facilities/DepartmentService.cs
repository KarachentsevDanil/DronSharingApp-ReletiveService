using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Facilities;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DepartmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddDepartment(AddDepartmentDto data)
        {
            var newDepartment = AutoMapper.Mapper.Map<AddDepartmentDto, Department>(data);
            _unitOfWork.DepartmentRepository.Add(newDepartment);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<DepartmentDto> GetDepartmentsByParams(DepartmentsFilterParams filterParams)
        {
            var items = _unitOfWork.DepartmentRepository.GetDepartmentsByParams(filterParams);

            var result = new CollectionResult<DepartmentDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Department>, List<DepartmentDto>>(items.Collection)
            };

            return result;
        }
    }
}
