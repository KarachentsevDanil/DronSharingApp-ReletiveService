using RCS.BLL.Dto.Residents;
using RCS.Domain.Params;

namespace RCS.BLL.Services.Contracts
{
    public interface IAppointmentService
    {
        void AddAppointment(AddAppointmentDto data);
        
        CollectionResult<AppointmentDto> GetAppointmentsByParams(AppointmentsFilterParams filterParams);
    }
}
