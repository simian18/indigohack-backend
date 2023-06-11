namespace DOTNET_WEB_SAMPLE.Models.Bookings
{
    public class Multicity
    {
        public int Id { get; set; }
        public String Source { get; set; }
        public String Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public int PassengersCount { get; set; }
        public String Currency { get; set; }
        public String Category { get; set; }
    }
}
