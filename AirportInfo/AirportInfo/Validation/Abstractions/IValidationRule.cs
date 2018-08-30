namespace AirportInfo.Validation.Abstractions
{
    public interface IValidationRule<T>
    {
        string ValidationMessaget { get; set; }

        bool Check(T value);
    }
}
