namespace BigCalculator.Validator
{
    using Core;

    public interface IValidator
    {
        Result<string> Validate(Data data);
    }
}
