using HospitalApplication.Domain.Models;
using HospitalApplication.Infrastructure.Data;
using HospitalApplication.Service.Base;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HospitalApplication.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectronicHealthRecordsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IElectronicHealthRecordService _electronicHealthRecordService;

        public ElectronicHealthRecordsController(ApplicationDbContext context, IElectronicHealthRecordService electronicHealthRecordService)
        {
            _context = context;
            _electronicHealthRecordService = electronicHealthRecordService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ElectronicHealthRecord>>> GetElectronicHealthRecords()
        {
            return await _context.ElectronicHealthRecords.ToListAsync();
        }

        // GET: api/Employees/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ElectronicHealthRecord>> GetElectronicHealthRecords(int id)
        {
            var ehr = await _context.ElectronicHealthRecords.FindAsync(id);

            if (ehr == null)
            {
                return NotFound();
            }

            return ehr;
        }

        // PUT: api/Appointments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElectronicHealthRecord(int id, ElectronicHealthRecord ehr)
        {
            if (id != ehr.Id)
            {
                return BadRequest();
            }

            _context.Entry(ehr).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElectronicHealthRecordExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Appointments
        [HttpPost]
        public async Task<ActionResult<ElectronicHealthRecord>> PostElectronicHealthRecord(ElectronicHealthRecord ehr)
        {
            _context.ElectronicHealthRecords.Add(ehr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElectronicHealthRecord", new { id = ehr.Id }, ehr);
        }

        // DELETE: api/Employees/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElectronicHealthRecord(int id)
        {
            var ehr = await _context.ElectronicHealthRecords.FindAsync(id);
            if (ehr == null)
            {
                return NotFound();
            }

            _context.ElectronicHealthRecords.Remove(ehr);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElectronicHealthRecordExists(int id)
        {
            return _context.ElectronicHealthRecords.Any(e => e.Id == id);
        }
    }
}
