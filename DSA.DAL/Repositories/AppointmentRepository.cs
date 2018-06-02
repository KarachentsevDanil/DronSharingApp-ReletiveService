using System.Collections.Generic;
using System.Linq;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using RCS.Domain.Facilities;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.Domain.Residents;
using RCS.Domain.Params;

namespace RCS.DAL.Repositories
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly RelativeCommunicationContext _dbContext;

        public AppointmentRepository(RelativeCommunicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public CollectionResult<Appointment> GetAppointmentsByParams(AppointmentsFilterParams parameters)
        {
            var appointments = GetAllAppointments();

            FillAppointmentsQueryParams(parameters);

            appointments = appointments.Where(parameters.Expression);

            var totalCount = appointments.Count();

            var result = appointments
                .OrderByDescending(x => x.Date)
                .Skip(parameters.Skip)
                .Take(parameters.Take)
                .AsNoTracking()
                .ToList();

            var appointmentsResult = new CollectionResult<Appointment>
            {
                Collection = result,
                TotalCount = totalCount
            };

            return appointmentsResult;
        }

        private IQueryable<Appointment> GetAllAppointments()
        {
            return _dbContext.Appointments.Include(t => t.User).AsQueryable();
        }

        private void FillAppointmentsQueryParams(AppointmentsFilterParams filterParams)
        {
            var predicate = PredicateBuilder.True<Appointment>();

            predicate = predicate.And(t => t.ResidentId == filterParams.ResidentId);

            if (filterParams.StartDate.HasValue && filterParams.EndDate.HasValue)
            {
                predicate = predicate.And(t => t.Date >= filterParams.StartDate.Value && t.Date <= filterParams.EndDate.Value);
            }

            filterParams.Expression = predicate;
        }
    }
}
