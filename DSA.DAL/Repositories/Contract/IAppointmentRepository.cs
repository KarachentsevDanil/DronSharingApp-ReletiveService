using System.Collections.Generic;
using RCS.Domain.Facilities;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.DAL.Repositories.Contract
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        CollectionResult<Appointment> GetAppointmentsByParams(AppointmentsFilterParams parameters);
    }
}
