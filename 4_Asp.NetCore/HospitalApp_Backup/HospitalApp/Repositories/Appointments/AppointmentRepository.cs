using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Appointments
{
    public class AppointmentRepository : Repository<Appointment> ,IAppointmentRepository
    {
        private readonly ApplicationDbContext _context;

        public AppointmentRepository(ApplicationDbContext context) : base(context) { }


        public Appointment GetAppointmentWithPatient(int Id)
        {
           return _context.Appointments.Include(a=>a.Patient).FirstOrDefault(a=>a.Id == Id);
        }

        public Appointment GetAppointmentsWithPatients()
        {
            IEnumerable<Appointment> appointments = _context.Appointments.Include(a => a.Patient).ToList();
            return (Appointment)appointments;
        }
    }
}
