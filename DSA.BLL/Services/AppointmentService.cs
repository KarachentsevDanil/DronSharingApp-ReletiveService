using System.Collections.Generic;
using RCS.BLL.Dto.Residents;
using RCS.BLL.Services.Contracts;
using RCS.DAL.UnitOfWork.Contract;
using RCS.Domain.Params;
using RCS.Domain.Residents;

namespace RCS.BLL.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public void AddAppointment(AddAppointmentDto data)
        {
            var newAppointment = AutoMapper.Mapper.Map<AddAppointmentDto, Appointment>(data);
            _unitOfWork.AppointmentRepository.Add(newAppointment);
            _unitOfWork.Commit();
        }
        
        public CollectionResult<AppointmentDto> GetAppointmentsByParams(AppointmentsFilterParams filterParams)
        {
            var appointments = _unitOfWork.AppointmentRepository.GetAppointmentsByParams(filterParams);

            var result = new CollectionResult<AppointmentDto>
            {
                TotalCount = appointments.TotalCount,
                Collection = AutoMapper.Mapper.Map<IEnumerable<Appointment>, List<AppointmentDto>>(appointments.Collection)
            };

            return result;
        }
    }
}
