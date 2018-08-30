using System.ComponentModel.DataAnnotations;

namespace AirportInfo.Models
{
    public class MainPageViewModel
    {
        public IValidatableObject<string> IATACode { get; set; }
    }
}
