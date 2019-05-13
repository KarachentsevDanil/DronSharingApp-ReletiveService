using System.Collections.Generic;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IObservationRepository : IRepository<Observation>
    {
        CollectionResult<Observation> GetResidentObservations(ObservationParams observationParams);
    }
}
