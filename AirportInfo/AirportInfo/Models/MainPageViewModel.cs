using System.Threading.Tasks;
using System.Windows.Input;
using AirportInfo.Validation;
using AirportInfo.Validation.Core;
using AirportInfo.Validation.Rules;
using Xamarin.Forms;

namespace AirportInfo.Models
{
    public class MainPageViewModel : ExtendedBindableObject
    {
        private ValidatableObject<string> _iATACode;

        private bool _isEnabled;
        private readonly int _iataSize = 3;

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

        public MainPageViewModel()
        {
            _iATACode = new ValidatableObject<string>(false);

            AddValidations();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);

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
