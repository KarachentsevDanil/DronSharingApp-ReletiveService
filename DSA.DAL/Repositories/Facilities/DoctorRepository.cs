using System.Collections.Generic;
using System.Linq;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Facilities;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public DoctorRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public CollectionResult<Doctor> GetDoctorsByParams(DoctorsFilterParams parameters)
        {
            var doctors = GetAllDoctors();

            FillDoctorQueryParams(parameters);

            doctors = doctors.Where(parameters.Expression);

            var totalCount = doctors.Count();

            var result = doctors
                .OrderBy(x => x.LastName)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var companiesResult = new CollectionResult<Doctor>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return companiesResult;
        }

        private IQueryable<Doctor> GetAllDoctors()
        {
            return _dbContext.Doctors
                .Include(t => t.DoctorSpecialization)
                .Include(t => t.Department)
                .ThenInclude(t => t.Facility)
                .AsQueryable();
        }

        private void FillDoctorQueryParams(DoctorsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.New<Doctor>(true);

            if (!string.IsNullOrEmpty(filterParams.Term))
            {
                predicate = predicate.And(t => t.LastName.Contains(filterParams.Term) || t.FirstName.Contains(filterParams.Term));
            }

            if (filterParams.FacilityId.HasValue)
            {
                predicate = predicate.And(t => t.Department.FacilityId == filterParams.FacilityId.Value);
            }

            if (filterParams.ResidentId.HasValue)
            {
                predicate = predicate.And(t => t.Residents.Any(r => r.ResidentId == filterParams.ResidentId.Value));
            }

            filterParams.Expression = predicate;
        }

        public IEnumerable<Doctor> GetDoctors(string term)
        {
            return _dbContext.Doctors
                .Where(t => t.FirstName.Contains(term) || t.LastName.Contains(term))
                .OrderBy(t => t.LastName).ToList(); ;
        }
    }
}
