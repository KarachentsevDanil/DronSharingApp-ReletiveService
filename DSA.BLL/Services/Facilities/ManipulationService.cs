using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class ManipulationService : IManipulationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ManipulationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddManipulation(AddManipulationDto data)
        {
            var newManipulation = AutoMapper.Mapper.Map<AddManipulationDto, Manipulation>(data);
            _unitOfWork.ManipulationRepository.Add(newManipulation);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<ManipulationDto> GetManipulationsByParams(ManipulationsFilterParams filterParams)
        {
            var items = _unitOfWork.ManipulationRepository.GetManipulationsByParams(filterParams);

            var result = new CollectionResult<ManipulationDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Manipulation>, List<ManipulationDto>>(items.Collection)
            };

            return result;
        }

        public IEnumerable<ManipulationDto> GetManipulationsByTerm(int facilityId, string term)
        {
            var items = _unitOfWork.ManipulationRepository.GetManipulationsByTerm(facilityId, term);
            return AutoMapper.Mapper.Map<IEnumerable<Manipulation>, List<ManipulationDto>>(items);
        }
    }
}
