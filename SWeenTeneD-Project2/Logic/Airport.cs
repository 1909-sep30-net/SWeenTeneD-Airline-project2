
namespace Logic
{
    public class Airport
    {
        //PK
        public string Name { get; set; }

        public string Location { get; set; }

        public string Weather { get; set; }

        public Airport(){}

        public Airport(int airportId, string airName, string airLocate, string airWeather)
        {
            Name = airName;
            Location = airLocate;
            Weather = airWeather;
        }
    }
}
