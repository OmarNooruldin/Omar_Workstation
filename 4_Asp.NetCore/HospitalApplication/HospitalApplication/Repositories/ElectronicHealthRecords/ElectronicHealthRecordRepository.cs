using HospitalApplication.Data;

namespace HospitalApplication.Repositories.ElectronicHealthRecords
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
