using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts.Residents
{
    public interface IResidentAnalyzesService
    {
        void AddResidentAnalyzes(AddResidentAnalyzesDto data);

        CollectionResult<ResidentAnalyzesDto> GetResidentAnalyzesByParams(ResidentAnalyzesFilterParams filterParams);
    }
}