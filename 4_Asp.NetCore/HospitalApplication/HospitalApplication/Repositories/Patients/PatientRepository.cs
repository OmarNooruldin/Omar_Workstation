using HospitalApplication.Data;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Patients
{
    public class PatientRepository : Repository<Patient> ,IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context) { }
    }
}
