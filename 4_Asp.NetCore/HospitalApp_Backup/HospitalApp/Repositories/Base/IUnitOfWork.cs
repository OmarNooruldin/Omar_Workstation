using HospitalApp.Models;
using HospitalApp.Repositories.Appointments;
using HospitalApp.Repositories.Billings;
using HospitalApp.Repositories.Doctors;
using HospitalApp.Repositories.Nurses;
using HospitalApp.Repositories.Patients;
using HospitalApp.Repositories.Permissions;
using HospitalApp.Repositories.Prescriptions;
using HospitalApp.Repositories.Roles;
using HospitalApp.Repositories.Users;

namespace HospitalApp.Repositories.Base
{
    public interface IUnitOfWork
    {
        Repository<Department> Departments { get; }
        Repository<ElectronicHealthRecord> ElectronicHealthRecords { get; }
        Repository<Permission> Permissions { get; }
        IRoleRepository Roles { get; }
        IUserRepository Users { get; }
        IAppointmentRepository Appointments {  get; }
        IBillingRepository Billings { get; }
        IDoctorRepository Doctors { get;}
        INurseRepository Nurses { get; }
        IPrescriptionRepository Prescriptions { get; }
        IPatientRepository Patients { get; }
        //IPermissionRepository Permissions {  get; }


        int Save();

    }
}
