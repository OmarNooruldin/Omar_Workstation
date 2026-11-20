using HospitalApp.Data;
using HospitalApp.Models;
using HospitalApp.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Repositories.Billings
{
    public class BillingRepository : Repository<Billing> ,IBillingRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRepository(ApplicationDbContext context) : base(context) { }

        public Billing GetBillingWithAppointment(int Id)
        {
            return _context.Billings.Include(b=>b.Appointment).FirstOrDefault(b=>b.Id == Id);
        }

        public IEnumerable<Billing> GetBillsWithAppointment()
        {
            return _context.Billings.Include(b => b.Appointment).ToList();
        }
    }
}
