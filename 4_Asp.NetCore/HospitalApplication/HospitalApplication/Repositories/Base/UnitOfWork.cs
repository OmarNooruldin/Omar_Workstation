using HospitalApplication.Data;
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
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        //public Repository<Appointment> Appointments { get; }

        //public Repository<Billing> Billings { get; }



        public Repository<ElectronicHealthRecord> ElectronicHealthRecords { get; }


        public Repository<Permission> Permissions { get; }

        public IRoleRepository Roles { get; }

        public IUserRepository Users { get; }

        public IAppointmentRepository Appointments {  get; }

        public IBillingRepository Billings { get; }

        public IDoctorRepository Doctors { get; }

        public IPrescriptionRepository Prescriptions { get; }

        public IPatientRepository Patients { get; }

        public IDepartmentRepository Departments { get; }   

        public UnitOfWork(ApplicationDbContext context) 
        {
            _context = context;
            Departments = new DepartmentRepository(_context);
            ElectronicHealthRecords = new Repository<ElectronicHealthRecord>(_context);
            Patients = new PatientRepository(_context);
            Permissions = new Repository<Permission>(_context);
            Roles = new RoleRepository(_context);
            Users = new UserRepository(_context);
            Appointments = new AppointmentRepository(_context);
            Billings = new BillingRepository(_context);
            Doctors = new DoctorRepository(_context);
            Prescriptions = new PrescriptionRepository(_context);
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        //public int Save()
        //{
        //    return _context.SaveChanges();
        //}
    }
}
