using System.Threading.Tasks;
using AirportInfo.Models;

namespace AirportInfo.Abstractions
{
    public interface IAirportInfoService
    {
        Task<Airport> GetAirportByIATAAsync(string iata);
    }
}
