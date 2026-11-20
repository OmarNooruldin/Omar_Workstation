
using HospitalApp.Models;
using HospitalApp.Repositories.Base;

namespace HospitalApp.Repositories.Billings
{
    public interface IBillingRepository : IRepository<Billing>
    {
        Billing GetBillingWithAppointment(int Id);
        IEnumerable<Billing> GetBillsWithAppointment();
    }
}
