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
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Billing> Billings { get; set; }
        public DbSet<ElectronicHealthRecord> ElectronicHealthRecords { get; set; }

    }
}
