using Newtonsoft.Json;

namespace AirportInfo.Models
{
    public class Airport
    {
        public string Country { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string IATA { get; set; }

        [JsonProperty("city_iata")]
        public string CityIATA { get; set; }

        [JsonProperty("country_iata")]
        public string CountryIATA { get; set; }

        public Coordinates Location { get; set; }

        public class Coordinates
        {
            [JsonProperty("lat")]
            public double Latitude { get; set; }

            [JsonProperty("lon")]
            public double Longitude { get; set; }
        }
    }
}
