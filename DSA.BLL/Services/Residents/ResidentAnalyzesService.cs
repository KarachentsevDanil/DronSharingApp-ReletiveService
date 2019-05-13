using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts.Residents;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class ResidentAnalyzesService : IResidentAnalyzesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ResidentAnalyzesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddResidentAnalyzes(AddResidentAnalyzesDto data)
        {
            var newResidentAnalyzes = AutoMapper.Mapper.Map<AddResidentAnalyzesDto, ResidentAnalyzes>(data);
            _unitOfWork.ResidentAnalyzesRepository.Add(newResidentAnalyzes);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<ResidentAnalyzesDto> GetResidentAnalyzesByParams(ResidentAnalyzesFilterParams filterParams)
        {
            var items = _unitOfWork.ResidentAnalyzesRepository.GetResidentAnalyzesByParams(filterParams);

            var result = new CollectionResult<ResidentAnalyzesDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<ResidentAnalyzes>, List<ResidentAnalyzesDto>>(items.Collection)
            };

            return result;
        }
    }
}
