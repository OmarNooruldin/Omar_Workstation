using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Prescriptions
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptionsWithEHR();
        Prescription GetPrescriptionWithEHR(int Id);
    }
}
