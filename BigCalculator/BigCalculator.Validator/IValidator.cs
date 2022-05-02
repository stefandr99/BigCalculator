namespace BigCalculator.Validator
{
    using Core;

    internal interface IValidator
    {
        Result<string> Validate(Data data);
    }
}
