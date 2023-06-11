namespace DOTNET_WEB_SAMPLE.Models.Flights
{
    public class AvailableFlights
    {
        public int id { get; set; }

        public String Source { get; set; }
        public String Destination { get; set; }
        public DateTime DeaprtureTime { get; set; }
        public String FlightCategory { get; set; }
        public int Price { get; set; }
    }
}
