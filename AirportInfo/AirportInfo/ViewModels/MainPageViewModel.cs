using System.Threading.Tasks;
using System.Windows.Input;
using AirportInfo.Abstractions;
using AirportInfo.Validation;
using AirportInfo.Validation.Core;
using AirportInfo.Validation.Rules;
using Xamarin.Forms;

namespace AirportInfo.ViewModels
{
    public class MainPageViewModel : ExtendedBindableObject
    {
        private readonly int _iataSize = 3;
        private ValidatableObject<string> _iATACode;
        private IAirportInfoService _airportService;
        private bool _isEnabled;
        private string _airport;

        public string Airport
        {
            get => _airport;
            set
            {
                _airport = value;
                RaisePropertyChanged(() => Airport);
            }
        }

        public ValidatableObject<string> IATACode
        {
            get => _iATACode;

            set
            {
                _iATACode = value;
                RaisePropertyChanged(() => IATACode);
            }
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                _isEnabled = value;
                RaisePropertyChanged(() => IsEnabled);
            }
        }

        public ICommand OnLostFocus => new Command(() => IATACode.Validate());

        public ICommand GetInfo => new Command(() => GetAirportInfoAsync());

        public MainPageViewModel()
        {
            _iATACode = new ValidatableObject<string>(false);
            _airportService = DependencyService.Get<IAirportInfoService>();
            AddValidations();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);

        private void GetAirportInfoAsync()
        {
            var airportInfo = _airportService.GetAirportByIATAAsync(IATACode.Value).GetAwaiter().GetResult();

            Airport = airportInfo?.Name;
        }

        private void AddValidations()
        {
            var lengthRule = new RequiredLengthRule<string>(_iataSize)
            {
                ValidationMessage = $"IATA Code must be exactly {_iataSize} characters!"
            };

            _iATACode.Validations.Add(lengthRule);
        }
    }
}
