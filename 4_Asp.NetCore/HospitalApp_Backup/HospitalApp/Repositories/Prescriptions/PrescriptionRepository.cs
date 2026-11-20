using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using HospitalApp.Repositories.Prescriptions;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Prescriptions
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
