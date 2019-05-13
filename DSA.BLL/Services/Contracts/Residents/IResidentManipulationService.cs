using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IResidentManipulationService
    {
        void AddResidentManipulation(AddResidentManipulationDto data);

        CollectionResult<ResidentManipulationDto> GetResidentManipulationsByParams(ResidentManipulationsFilterParams filterParams);
    }
}