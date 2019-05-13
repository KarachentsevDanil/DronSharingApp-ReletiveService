using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;
using System.Collections.Generic;

namespace RCS.BLL.Services.Contracts
{
    public interface IObservationService
    {
        void AddObservation(AddObservationDto data);

        CollectionResult<ObservationDto> GetObservationsByParams(ObservationParams filterParams);
    }
}
