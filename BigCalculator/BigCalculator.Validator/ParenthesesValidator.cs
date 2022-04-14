namespace BigCalculator.Validator
{
    using Core;

    internal class ParenthesesValidator : IValidator
    {
        public Result<string> Validate(string expression)
        {
            int opened = 0;

            foreach (var c in expression)
            {
                if (c == '(')
                    opened++;
                else if (c == ')')
                    opened--;

                if (opened < 0)
                    return new InvalidResult<string>("Invalid parentheses!");
            }

            return new SuccessResult<string>("Success!");
        }
    }
}
