using DOTNET_WEB_SAMPLE.Models.Bookings;
using DOTNET_WEB_SAMPLE.Models.Flights;
using Microsoft.EntityFrameworkCore;

namespace DOTNET_WEB_SAMPLE.Data
{
    public class Appdbcontext: DbContext
    {
        public Appdbcontext(DbContextOptions<Appdbcontext> options): base(options) { 
        }
         public DbSet<AvailableFlights> flights { get; set; }
        public DbSet<OneWay> OneWays { get; set; }
        public DbSet<RoundTrip> RoundTrips { get; set; }
        public DbSet<Multicity> Multicities { get; set; }
    }
}
