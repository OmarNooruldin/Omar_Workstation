using HospitalApplication.Application.Abstractions.Repositories;
using HospitalApplication.Infrastructure.Data;

namespace HospitalApplication.Infrastructure.Persistences.Repositories
{
    public class ElectronicHealthRecordRepository : IElectronicHealthRecordRepository
    {
        private readonly ApplicationDbContext _context;

        public ElectronicHealthRecordRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
