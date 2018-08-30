using AirportInfo.Validation.Abstractions;

namespace AirportInfo.Validation.Rules
{
    public class IsNotNullOrEmptyRule<T> : IValidationRule<T>
    {
        public string ValidationMessaget { get; set; }

        public bool Check(T value) => value == null ? false : !string.IsNullOrWhiteSpace(value as string);
    }
}
