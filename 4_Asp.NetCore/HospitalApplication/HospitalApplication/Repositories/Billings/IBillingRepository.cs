using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;

namespace HospitalApplication.Repositories.Billings
{
    public interface IBillingRepository : IRepository<Billing>
    {
        Billing GetBillingWithAppointment(int Id);
        IEnumerable<Billing> GetBillsWithAppointment();
    }
}
