using RCS.BLL.Dto.Facilities;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services.Contracts
{
    public interface IManipulationService
    {
        void AddManipulation(AddManipulationDto data);
        
        CollectionResult<ManipulationDto> GetManipulationsByParams(ManipulationsFilterParams filterParams);

        IEnumerable<ManipulationDto> GetManipulationsByTerm(int facilityId, string term);
    }
}