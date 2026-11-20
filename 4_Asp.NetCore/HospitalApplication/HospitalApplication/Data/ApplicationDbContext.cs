using HospitalApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<ElectronicHealthRecord> ElectronicHealthRecords { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<User> Users  { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }

    }
}
