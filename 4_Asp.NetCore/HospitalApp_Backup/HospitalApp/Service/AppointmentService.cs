using HospitalApp.Dtos;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Service.Base;


namespace HospitalApp.Service
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AppointmentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void CreateAppointment(AppointmentCreateDto appointment)
        {
            var appointments = new Appointment
            {
                AppointmentDate = appointment.AppointmentDate,
                ReasonForVisit = appointment.ReasonForVisit,
                Status = appointment.Status,
                PatientId = appointment.PatientLastName,
                DoctorId = appointment?.DoctorId,
            };
            _unitOfWork.Appointments.Add(appointments);
        }

        public void DeleteAppointment(int Id)
        {
            var appointment = _unitOfWork.Appointments.GetById(Id);
            if (appointment == null)
            {
                return ;
            }
            _unitOfWork.Appointments.Delete(appointment);
        }

        public IEnumerable<AppointmentListDto> GetAllAppointments()
        {
            var appointments = _unitOfWork.Appointments.GetAll();
            return appointments.Select(a => new AppointmentListDto
            {
                Id = a.Id,
                AppointmentDate = a.AppointmentDate,
                ReasonForVisit = a.ReasonForVisit,
                Status = a.Status,
                PatientLastName = a.Patient?.LastName ?? "Unknown Patient",
                DoctorLastName = a?.Doctor != null ? a.Doctor?.LastName : null
            });
        }

        public IEnumerable<DoctorListDto> GetAllDoctors()
        {
            var doctors = _unitOfWork.Doctors.GetAll();
            return doctors.Select(d => new DoctorListDto
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                LicenseNumber = d.LicenseNumber,
                Speciality = d.Speciality,
                ConsultationFee = d?.ConsultationFee,
            });
        }

        public IEnumerable<PatientListDto> GetAllPatients()
        {
            var patients = _unitOfWork.Patients.GetAll();
            return patients.Select(p => new PatientListDto
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                DateOfBirth = p.DateOfBirth,
                Gender = p.Gender,
                BloodGroup = p.BloodGroup,
                ContactNumber = p.ContactNumber,
                EmergencyContactName = p.EmergencyContactName,
                EmergencyContactPhone = p.EmergencyContactPhone,
                Address = p?.Address,
                Email = p?.Email,
            });
        }

        public AppointmentUpdateDto GetAppointmentById(int Id)
        {
            var appointment = _unitOfWork.Appointments.GetById(Id);
            if (appointment == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            return new AppointmentUpdateDto
            {
                AppointmentDate = appointment.AppointmentDate,
                ReasonForVisit = appointment.ReasonForVisit,
                Status = appointment.Status,
                PatientLastName = appointment.PatientId,
                DoctorId = appointment?.DoctorId,
            };
        }

        public int SaveAppointments()
        {
            return _unitOfWork.Save();
        }

        public void UpdateAppointment(AppointmentUpdateDto appointment)
        {
            var appointments = _unitOfWork.Appointments.GetById(appointment.Id);
            if (appointments == null)
            {
                throw new KeyNotFoundException("Not Found");
            }
            appointments.AppointmentDate = appointment.AppointmentDate;
            appointments.ReasonForVisit = appointment.ReasonForVisit;
            appointments.Status = appointment.Status;
            appointments.PatientId = appointment.PatientLastName;
            appointments?.DoctorId = appointment?.DoctorId;
            

            _unitOfWork.Appointments.Update(appointments);
        }
    }
}
