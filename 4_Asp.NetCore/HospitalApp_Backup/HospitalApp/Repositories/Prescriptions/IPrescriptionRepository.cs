using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Prescriptions
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptionsWithEHR();
        Prescription GetPrescriptionWithEHR(int Id);
    }
}
