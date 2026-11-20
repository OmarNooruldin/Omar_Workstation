using HospitalApplication.Models;
using HospitalApplication.Repositories.Appointments;
using HospitalApplication.Repositories.Billings;
using HospitalApplication.Repositories.Departments;
using HospitalApplication.Repositories.Doctors;
using HospitalApplication.Repositories.Patients;
using HospitalApplication.Repositories.Prescriptions;
using HospitalApplication.Repositories.Roles;
using HospitalApplication.Repositories.Users;

namespace HospitalApplication.Repositories.Base
{
    public interface IUnitOfWork
    {
        Repository<ElectronicHealthRecord> ElectronicHealthRecords { get; }
        Repository<Permission> Permissions { get; }
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
