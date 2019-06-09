using RCS.BLL.Dto.Facilities;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;
using System.Collections.Generic;

namespace RCS.BLL.Services
{
    public class AnalyzesService : IAnalyzesService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AnalyzesService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddAnalyzes(AddAnalyzesDto data)
        {
            var newAnalyzes = AutoMapper.Mapper.Map<AddAnalyzesDto, Analyzes>(data);
            _unitOfWork.AnalyzesRepository.Add(newAnalyzes);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<AnalyzesDto> GetAnalyzesByParams(AnalyzesFilterParams filterParams)
        {
            var items = _unitOfWork.AnalyzesRepository.GetAnalyzesByParams(filterParams);

            var result = new CollectionResult<AnalyzesDto>
            {
                TotalCount = items.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Analyzes>, List<AnalyzesDto>>(items.Collection)
            };

            return result;
        }

        public IEnumerable<AnalyzesDto> GetAnalyzesByTerm(int facilityId, string term)
        {
            var items = _unitOfWork.AnalyzesRepository.GetAnalyzesByTerm(facilityId, term);
            return AutoMapper.Mapper.Map<IEnumerable<Analyzes>, List<AnalyzesDto>>(items);
        }
    }
}
