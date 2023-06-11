using DOTNET_WEB_SAMPLE.Data;
using DOTNET_WEB_SAMPLE.Models.Bookings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_WEB_SAMPLE.Controllers.Bookings
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundwayController : ControllerBase
    {
        private readonly Appdbcontext _db;

        public RoundwayController(Appdbcontext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoundTrip>>> GetRoundTrips()
        {
            if (_db.RoundTrips == null)
            {
                return NotFound();
            }
            else
            {
                return await _db.RoundTrips.ToListAsync();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RoundTrip>> GetRoundTrip(int id)
        {
            var oneway = await _db.RoundTrips.FindAsync(id);
            if (_db.OneWays == null)
            {
                return NotFound();
            }
            return oneway;
        }

        [HttpPost]
        public async Task<ActionResult<RoundTrip>> PostRoundTrip(RoundTrip oneWay)
        {

            if (_db.OneWays == null)
            {
                return BadRequest();
            }
            await _db.RoundTrips.AddAsync(oneWay);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<RoundTrip>> DeleteRoundTrip(int id)
        {
            var oneway = await _db.RoundTrips.FindAsync(id);
            if (_db.OneWays == null)
            {
                return NotFound();
            }
            _db.RoundTrips.Remove(oneway);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
