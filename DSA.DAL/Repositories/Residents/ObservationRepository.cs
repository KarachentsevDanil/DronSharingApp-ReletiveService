using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories
{
    public class ObservationRepository : Repository<Observation>, IObservationRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public ObservationRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public CollectionResult<Observation> GetResidentObservations(ObservationParams observationParams)
        {
            var observations = GetAllObservations();

            var query = FillObservationQueryParams(observationParams);

            observations = observations.Where(query);

            var totalCount = observations.Count();

            var result = observations
                .OrderByDescending(t => t.RecordedDate)
                .Skip(observationParams.Skip)
                .Take(observationParams.Take)
                .AsNoTracking()
                .ToList();

            var observationsResult = new CollectionResult<Observation>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return observationsResult;
        }

        private IQueryable<Observation> GetAllObservations()
        {
            return _dbContext.Observations.AsQueryable();
        }

        private Expression<Func<Observation, bool>> FillObservationQueryParams(ObservationParams filterParams)
        {
            var predicate = PredicateBuilder.New<Observation>(t => t.ResidentId == filterParams.ResidentId);

            if (filterParams.Type.HasValue)
            {
                predicate = predicate.And(t => t.Type == filterParams.Type);
            }

            if (filterParams.StartDate.HasValue && filterParams.EndDate.HasValue)
            {
                predicate = predicate.And(t => t.RecordedDate >= filterParams.StartDate.Value && t.RecordedDate <= filterParams.EndDate.Value);
            }

            return predicate;
        }
    }
}
