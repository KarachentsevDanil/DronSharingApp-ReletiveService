using System.Collections.Generic;
using System.Linq;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Params;
using LinqKit;
using RCS.Domain.Facilities;

namespace RCS.DAL.Repositories
{
    public class DoctorSpecializationRepository : Repository<DoctorSpecialization>, IDoctorSpecializationRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public DoctorSpecializationRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IEnumerable<DoctorSpecialization> GetDoctorSpecializations(string term)
        {
            return _dbContext.DoctorSpecializations.Where(t => t.Name.Contains(term)).ToList();
        }

        public CollectionResult<DoctorSpecialization> GetDoctorSpecializationsByParams(DoctorSpecializationsFilterParams parameters)
        {
            var specializations = GetAllSpecializations();

            FillSpecializationsQueryParams(parameters);

            specializations = specializations.Where(parameters.Expression);

            var totalCount = specializations.Count();

            var result = specializations
                .OrderBy(x => x.Name)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var modelsResult = new CollectionResult<DoctorSpecialization>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return modelsResult;
        }

        private IQueryable<DoctorSpecialization> GetAllSpecializations()
        {
            return _dbContext.DoctorSpecializations
                .AsQueryable();
        }

        private void FillSpecializationsQueryParams(DoctorSpecializationsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<DoctorSpecialization>();

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.And(t => t.Name.Contains(filterParams.Term));
            }

            filterParams.Expression = predicate;
        }
    }
}
