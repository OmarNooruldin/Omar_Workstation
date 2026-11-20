using HospitalApplication.Data;
using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Repositories.Appointments
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
