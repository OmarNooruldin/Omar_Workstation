using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Appointments
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Appointment GetAppointmentWithPatient(int Id);

        IEnumerable<Appointment> GetAppointmentsWithPatients();
    }
}
