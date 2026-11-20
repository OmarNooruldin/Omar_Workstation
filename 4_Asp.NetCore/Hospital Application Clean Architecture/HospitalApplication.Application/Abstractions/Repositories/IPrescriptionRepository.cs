using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IPrescriptionRepository : IRepository<Prescription>
    {
        IEnumerable<Prescription> GetAllPrescriptionsWithEHR();
        Prescription GetPrescriptionWithEHR(int Id);
    }
}
