using HospitalApplication.Application.Abstractions.Repositories.Base;
using HospitalApplication.Domain.Models;

namespace HospitalApplication.Application.Abstractions.Repositories
{
    public interface IBillingRepository : IRepository<Billing>
    {
        Billing GetBillingWithAppointment(int Id);
        IEnumerable<Billing> GetBillsWithAppointment();
    }
}
