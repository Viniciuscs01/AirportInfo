using AirportInfo.Validation.Abstractions;

namespace AirportInfo.Validation.Rules
{
    public class RequiredLengthRule<T> : IValidationRule<T>
    {
        private readonly int requiredLength;

        public string ValidationMessage { get; set; }

        public RequiredLengthRule(int requiredLength) => this.requiredLength = requiredLength;

        public bool Check(T value)
            => typeof(T) != typeof(string) ? true : value?.ToString()?.Length == requiredLength;
    }
}
