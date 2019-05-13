using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IManipulationService
    {
        void AddManipulation(AddManipulationDto data);
        
        CollectionResult<ManipulationDto> GetManipulationsByParams(ManipulationsFilterParams filterParams);
    }
}