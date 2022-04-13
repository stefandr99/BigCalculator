namespace BigCalculator.Validator
{
    using Core;
    using System.Text.RegularExpressions;

    internal class SymbolsValidator : IValidator
    {
        public Result<string> Validate(string expression)
        {
            var pattern = @"^[0-9()+-*/^]+$";

            if (! Regex.IsMatch(expression, pattern))
            {
                return new InvalidResult<string>("Invalid symbols!");
            }

            return new SuccessResult<string>("Success!");
        }
    }
}
