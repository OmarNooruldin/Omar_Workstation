using HospitalApp.Dtos;

namespace HospitalApp.Service.Base
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentListDto> GetAllAppointments();
        IEnumerable<PatientListDto> GetAllPatients();
        IEnumerable<DoctorListDto> GetAllDoctors();


        void CreateAppointment(AppointmentCreateDto appointment);
        void UpdateAppointment(AppointmentUpdateDto appointment);
        void DeleteAppointment(int Id);

        AppointmentUpdateDto GetAppointmentById(int Id);

        int SaveAppointments();

    }
}
