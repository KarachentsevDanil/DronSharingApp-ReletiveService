using RCS.DAL.Repositories.Contract;

namespace RCS.DAL.UnitOfWork.Contract
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository { get; set; }

        IFacilityRepository FacilityRepository { get; set; }

        IDoctorSpecializationRepository DoctorSpecializationRepository { get; set; }

        IDoctorRepository DoctorRepository { get; set; }

        IObservationRepository ObservationRepository { get; set; }

        IResidentRepository ResidentRepository { get; set; }

        IAppointmentRepository AppointmentRepository { get; set; }

        IResidentContactRepository ResidentContactRepository { get; set; }

        IAnalyzesRepository AnalyzesRepository { get; set; }

        IDepartmentRepository DepartmentRepository { get; set; }

        IDrugRepository DrugRepository { get; set; }

        IManipulationRepository ManipulationRepository { get; set; }

        IResidentAnalyzesRepository ResidentAnalyzesRepository { get; set; }

        IResidentDrugRepository ResidentDrugRepository { get; set; }

        IResidentManipulationRepository ResidentManipulationRepository { get; set; }

        IResidentDoctorRepository ResidentDoctorRepository { get; set; }

        void Commit();
    }
}
