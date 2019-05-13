using Autofac;
using RCS.BLL.Services;
using RCS.BLL.Services.Contracts;
using RCS.BLL.Services.Contracts.Residents;

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

            builder.RegisterType<AnalyzesService>().As<IAnalyzesService>();
            builder.RegisterType<DepartmentService>().As<IDepartmentService>();
            builder.RegisterType<DrugService>().As<IDrugService>();
            builder.RegisterType<ManipulationService>().As<IManipulationService>();
            builder.RegisterType<ResidentManipulationService>().As<IResidentManipulationService>();
            builder.RegisterType<ResidentAnalyzesService>().As<IResidentAnalyzesService>();
            builder.RegisterType<ResidentDrugService>().As<IResidentDrugService>();
        }
    }
}
