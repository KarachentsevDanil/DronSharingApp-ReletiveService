using Autofac;
using RCS.BLL.Services;
using RCS.BLL.Services.Contracts;

namespace RCS.WebApi.Modules
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AppointmentService>().As<IAppointmentService>();
            builder.RegisterType<DoctorService>().As<IDoctorService>();
            builder.RegisterType<DoctorSpecializationService>().As<IDoctorSpecializationService>();
            builder.RegisterType<FacilityService>().As<IFacilityService>();
            builder.RegisterType<ObservationService>().As<IObservationService>();
            builder.RegisterType<ResidentContactService>().As<IResidentContactService>();
            builder.RegisterType<ResidentDoctorService>().As<IResidentDoctorService>();
            builder.RegisterType<ResidentService>().As<IResidentService>();
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
