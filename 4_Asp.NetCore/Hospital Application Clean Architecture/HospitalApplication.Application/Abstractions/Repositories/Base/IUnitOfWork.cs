using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories.Base
{
    public interface IUnitOfWork
    {
        IRepository<ElectronicHealthRecord> ElectronicHealthRecords { get; }
        IRepository<Permission> Permissions { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IAppointmentRepository Appointments {  get; }
        IBillingRepository Billings { get; }
        IDoctorRepository Doctors { get;}
        IDepartmentRepository Departments { get; }
        IPrescriptionRepository Prescriptions { get; }
        IPatientRepository Patients { get; }


        void Save();

    }
}
