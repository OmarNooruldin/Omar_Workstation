using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        Appointment GetAppointmentWithPatient(int Id);

        IEnumerable<Appointment> GetAppointmentsWithPatients();
    }
}
