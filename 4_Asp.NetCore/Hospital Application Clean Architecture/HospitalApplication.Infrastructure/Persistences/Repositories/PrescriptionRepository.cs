using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class PrescriptionRepository : Repository<Prescription>, IPrescriptionRepository
    {
        public PrescriptionRepository(ApplicationDbContext context) : base(context) { }

        public IEnumerable<Prescription> GetAllPrescriptionsWithEHR()
        {
            return _context.Prescriptions.Include(p => p.ElectronicHealthRecord).ToList();
        }

        public Prescription GetPrescriptionWithEHR(int Id)
        {
            return _context.Prescriptions.Include(p=>p.ElectronicHealthRecord).FirstOrDefault(p=>p.Id == Id);
        }
    }
}
