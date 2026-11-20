using HospitalApp.Data;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        //public Repository<Appointment> Appointments { get; }

        //public Repository<Billing> Billings { get; }

        public Repository<Department> Departments { get; }

        public Repository<ElectronicHealthRecord> ElectronicHealthRecords { get; }


        public Repository<Permission> Permissions { get; }

        public IRoleRepository Roles { get; }

        public IUserRepository Users { get; }

        public IAppointmentRepository Appointments {  get; }

        public IBillingRepository Billings { get; }

        public IDoctorRepository Doctors { get; }

        public INurseRepository Nurses { get; }

        public IPrescriptionRepository Prescriptions { get; }

        public IPatientRepository Patients { get; }

        //public IPermissionRepository Permissions { get; }

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Departments = new Repository<Department>(_context);
            ElectronicHealthRecords = new Repository<ElectronicHealthRecord>(_context);
            Patients = new PatientRepository(_context);
            Permissions = new Repository<Permission>(_context);
            //Permissions = new PermissionRepository(_context);
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Billings = new BillingRepository(_context);
            Doctors = new DoctorRepository(_context);
            Nurses = new NurseRepository(_context);
            Prescriptions = new PrescriptionRepository(_context);
        }


        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
