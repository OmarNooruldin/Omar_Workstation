using HospitalApp.Models;
using HospitalApp.Repositories.Base;


namespace HospitalApp.Repositories.Appointments
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Appointment GetAppointmentWithPatient(int Id);
    }
}
