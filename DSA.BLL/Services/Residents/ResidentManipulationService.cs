using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class ResidentManipulationService : IResidentManipulationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentManipulationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddResidentManipulation(AddResidentManipulationDto data)
        {
            var newResidentManipulation = AutoMapper.Mapper.Map<AddResidentManipulationDto, ResidentManipulation>(data);
            _unitOfWork.ResidentManipulationRepository.Add(newResidentManipulation);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<ResidentManipulationDto> GetResidentManipulationsByParams(ResidentManipulationsFilterParams filterParams)
        {
            var items = _unitOfWork.ResidentManipulationRepository.GetResidentManipulationsByParams(filterParams);

            var result = new CollectionResult<ResidentManipulationDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<ResidentManipulation>, List<ResidentManipulationDto>>(items.Collection)
            };

            return result;
        }
    }
}
