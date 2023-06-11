using DOTNET_WEB_SAMPLE.Data;
using DOTNET_WEB_SAMPLE.Models.Bookings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_WEB_SAMPLE.Controllers.Bookings
{
    [Route("api/[controller]")]
    [ApiController]
    public class MulticityController : ControllerBase
    {
        private readonly Appdbcontext _db;

        public MulticityController(Appdbcontext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Multicity>>> GetMulticity()
        {
            if (_db.Multicities == null)
            {
                return NotFound();
            }
            else
            {
                return await _db.Multicities.ToListAsync();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Multicity>> GetRoundTrip(int id)
        {
            var oneway = await _db.Multicities.FindAsync(id);
            if (_db.OneWays == null)
            {
                return NotFound();
            }
            return oneway;
        }

        [HttpPost]
        public async Task<ActionResult<Multicity>> PostRoundTrip(Multicity oneWay)
        {

            if (_db.Multicities == null)
            {
                return BadRequest();
            }
            await _db.Multicities.AddAsync(oneWay);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Multicity>> DeleteRoundTrip(int id)
        {
            var oneway = await _db.Multicities.FindAsync(id);
            if (_db.Multicities == null)
            {
                return NotFound();
            }
            _db.Multicities.Remove(oneway);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
