using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using AirportInfo.Validation.Abstractions;
using AirportInfo.Validation.Core;

namespace AirportInfo.Validation
{
    public class ValidatableObject<T> : ExtendedBindableObject, IValidity
    {
        private bool _isValid;
        private T _value;
        public ObservableCollection<string> Errors { get; }

        public bool IsValid
        {
            get => _isValid;

            set
            {
                _isValid = value;
                RaisePropertyChanged(() => IsValid);
            }
        }

        public List<IValidationRule<T>> Validations { get; }

        public T Value
        {
            get => _value;

            set
            {
                _value = value;
                RaisePropertyChanged(() => Value);
            }
        }

        public ValidatableObject(bool initialStateValid = true)
        {
            _isValid = initialStateValid;
            Errors = new ObservableCollection<string>();
            Errors.CollectionChanged += Errors_CollectionChanged;
            Validations = new List<IValidationRule<T>>();
        }

        public bool Validate()
        {
            Errors.Clear();

            var errors = Validations.Where(v => !v.Check(Value))
                                     .Select(v => v.ValidationMessage);

            foreach (var error in errors)
            {
                Errors.Add(error);
            }

            IsValid = !Errors.Any();

            return IsValid;
        }

        private void Errors_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
                    => RaisePropertyChanged(() => Errors);
    }
}
