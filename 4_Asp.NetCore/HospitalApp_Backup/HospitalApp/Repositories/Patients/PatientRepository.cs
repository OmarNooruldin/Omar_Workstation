using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Repositories.Patients;

namespace HospitalApp.Repositories.Patients
{
    public class PatientRepository : Repository<Patient> ,IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context) { }
    }
}
