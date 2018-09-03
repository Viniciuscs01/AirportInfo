using System;
using System.Net.Http;
using System.Threading.Tasks;
using AirportInfo.Abstractions;
using AirportInfo.Helpers;
using AirportInfo.Models;

namespace AirportInfo.Services
{
    public class AirportInfoService : IAirportInfoService
    {
        private readonly Uri _airportInfoApiUrl;
        private HttpClient _client;

        public AirportInfoService()
        {
            _airportInfoApiUrl = Settings.AirportApiUrl;
            _client = HttpClientFactory.Create();
        }

        public async Task<Airport> GetAirportByIATAAsync(string iata)
        {
            var response = await _client.GetAsync(_airportInfoApiUrl + iata);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                return null;
            }

            var result = await response.Content.ReadAsAsync<Airport>();

            return result;
        }
    }
}
