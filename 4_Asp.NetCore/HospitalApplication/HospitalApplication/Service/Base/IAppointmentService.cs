using HospitalApplication.Dtos;

namespace HospitalApplication.Service.Base
{
    public interface IAppointmentService
    {
        IEnumerable<AppointmentListDto> GetAllAppointments();
        IEnumerable<PatientListDto> GetAllPatients();
        IEnumerable<DoctorListDto> GetAllDoctors();


        void CreateAppointment(AppointmentCreateDto appointment);
        void UpdateAppointment(AppointmentListDto appointment);
        void DeleteAppointment(int Id);

        AppointmentListDto GetAppointmentById(int Id);

        void SaveAppointments();

    }
}
