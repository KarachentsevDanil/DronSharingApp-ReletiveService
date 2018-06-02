using System.Collections.Generic;
using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services
{
    public class FacilityService : IFacilityService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FacilityService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddFacility(AddFacilityDto data)
        {
            var newFacility = AutoMapper.Mapper.Map<AddFacilityDto, Facility>(data);
            _unitOfWork.FacilityRepository.Add(newFacility);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<FacilityDto> GetFacilitiesByParams(FacilitiesFilterParams filterParams)
        {
            var facilities = _unitOfWork.FacilityRepository.GetFacilitiesByParams(filterParams);

            var result = new CollectionResult<FacilityDto>
            {
                TotalCount = facilities.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Facility>, List<FacilityDto>>(facilities.Collection)
            };

            return result;
        }

        public IEnumerable<FacilityDto> GetFacilitiesByTerm(string term)
        {
            var facilities = _unitOfWork.FacilityRepository.GetFacilitiesByTerm(term);
            return AutoMapper.Mapper.Map<IEnumerable<Facility>, List<FacilityDto>>(facilities);
        }
    }
}
