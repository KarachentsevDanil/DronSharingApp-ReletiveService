using Autofac;
using RCS.DAL.Context;
using RCS.DAL.Repositories;
using RCS.DAL.Repositories.Contract;
using RCS.DAL.UnitOfWork;
using RCS.DAL.UnitOfWork.Contract;

namespace RCS.WebApi.Modules
{
    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RelativeCommunicationContext>().As<RelativeCommunicationContext>().InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().PropertiesAutowired();
            builder.RegisterType<AppointmentRepository>().As<IAppointmentRepository>();
            builder.RegisterType<DoctorRepository>().As<IDoctorRepository>();
            builder.RegisterType<DoctorSpecializationRepository>().As<IDoctorSpecializationRepository>();
            builder.RegisterType<FacilityRepository>().As<IFacilityRepository>();
            builder.RegisterType<ObservationRepository>().As<IObservationRepository>();
            builder.RegisterType<ResidentContactRepository>().As<IResidentContactRepository>();
            builder.RegisterType<ResidentDoctorRepository>().As<IResidentDoctorRepository>();
            builder.RegisterType<ResidentRepository>().As<IResidentRepository>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
        }
    }
}
