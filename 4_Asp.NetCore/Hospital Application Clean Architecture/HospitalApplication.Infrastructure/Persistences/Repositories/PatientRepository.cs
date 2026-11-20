using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class PatientRepository : Repository<Patient> ,IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context) : base(context) { }
    }
}
