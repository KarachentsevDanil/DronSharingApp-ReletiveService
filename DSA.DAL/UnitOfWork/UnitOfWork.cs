using System;
using RCS.DAL.Context;
using RCS.DAL.Repositories.Contract;
using RCS.DAL.UnitOfWork.Contract;

namespace RCS.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly RelativeCommunicationContext _context;

        public UnitOfWork(RelativeCommunicationContext context)
        {
            _context = context;
        }

        public IUserRepository UserRepository { get; set; }

        public IFacilityRepository FacilityRepository { get; set; }

        public IDoctorSpecializationRepository DoctorSpecializationRepository { get; set; }

        public IDoctorRepository DoctorRepository { get; set; }

        public IObservationRepository ObservationRepository { get; set; }

        public IResidentRepository ResidentRepository { get; set; }

        public IAppointmentRepository AppointmentRepository { get; set; }

        public IResidentContactRepository ResidentContactRepository { get; set; }

        public IResidentDoctorRepository ResidentDoctorRepository { get; set; }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
