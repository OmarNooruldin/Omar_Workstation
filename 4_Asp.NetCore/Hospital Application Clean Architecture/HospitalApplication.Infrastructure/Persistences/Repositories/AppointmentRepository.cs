using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class AppointmentRepository : Repository<Appointment> ,IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) : base(context) { }


        public Appointment GetAppointmentWithPatient(int Id)
        {
           return _context.Appointments.Include(a=>a.Patient).FirstOrDefault(a=>a.Id == Id);
        }

        public IEnumerable<Appointment> GetAppointmentsWithPatients()
        {
            return _context.Appointments.Include(a => a.Patient).ToList();
        }
    }
}
