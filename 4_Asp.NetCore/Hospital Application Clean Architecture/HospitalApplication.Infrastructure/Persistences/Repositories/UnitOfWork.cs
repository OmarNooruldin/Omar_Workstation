using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;


namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;


        //public Repository<Appointment> Appointments { get; }

        //public Repository<Billing> Billings { get; }



        public IRepository<ElectronicHealthRecord> ElectronicHealthRecords { get; }

        public IRepository<Permission> Permissions { get; }

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
