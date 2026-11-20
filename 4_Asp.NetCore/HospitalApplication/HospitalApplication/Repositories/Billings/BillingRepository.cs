using HospitalApplication.Data;
using HospitalApplication.Dtos;
using HospitalApplication.Models;
using HospitalApplication.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Repositories.Billings
{
    public class BillingRepository : Repository<Billing> ,IBillingRepository
    {
        private readonly ApplicationDbContext _context;

        public BillingRepository(ApplicationDbContext context) : base(context) { }

        public Billing GetBillingWithAppointment(int Id)
        {
            var bill =  _context.Billings.Include(b=>b.Appointment).FirstOrDefault(b=>b.Id == Id);
            return bill;
        }

        public IEnumerable<Billing> GetBillsWithAppointment()
        {
            return _context.Billings.Include(b => b.Appointment).ToList();
        }
    }
}
