namespace BigCalculator.Validator
{
    using Core;
    using System.Text.RegularExpressions;

    public class SymbolsValidator : IValidator
    {
        public Result<string> Validate(Data data)
        {
            var pattern = @"^[a-z()+\-*/^#]+$";

            if (!Regex.IsMatch(data.Expression, pattern))
            {
                return new InvalidResult<string>("Invalid symbols!");
            }

            return new SuccessResult<string>("Success!");
        }
    }
}
