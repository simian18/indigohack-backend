using DOTNET_WEB_SAMPLE.Data;
using DOTNET_WEB_SAMPLE.Models.Bookings;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_WEB_SAMPLE.Controllers.Bookings
{
    [Route("api/[controller]")]
    [ApiController]
    public class OnewayController : ControllerBase
    {
        private readonly Appdbcontext _db;

        public OnewayController(Appdbcontext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OneWay>>> GetOneways(){
            if(_db.OneWays == null)
            {
                return NotFound();
            }
            else
            {
                return await _db.OneWays.ToListAsync();
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<OneWay>> GetOneway(int id)
        {
            var oneway = await _db.OneWays.FindAsync(id);
            if (_db.OneWays == null)
            {
                return NotFound();
            }
            return oneway;
        }

        [HttpPost]
        public async Task<ActionResult<OneWay>> PostOneway(OneWay oneWay)
        {
            
            if (_db.OneWays == null)
            {
                return BadRequest();
            }
            await _db.OneWays.AddAsync(oneWay);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<OneWay>> DeleteOneway(int id)
        {
            var oneway = await _db.OneWays.FindAsync(id);
            if (_db.OneWays == null)
            {
                return NotFound();
            }
            _db.OneWays.Remove(oneway);
            await _db.SaveChangesAsync();
            return Ok();
        }
    }
}
