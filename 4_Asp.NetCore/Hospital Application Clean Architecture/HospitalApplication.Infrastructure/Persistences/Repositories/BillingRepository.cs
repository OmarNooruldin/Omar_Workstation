using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
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
