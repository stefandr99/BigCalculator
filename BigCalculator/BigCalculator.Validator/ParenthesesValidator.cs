namespace BigCalculator.Validator
{
    using Core;

    internal class ParenthesesValidator : IValidator
    {
        public Result<string> Validate(Data data)
        {
            int opened = 0;

            foreach (var c in data.Expression)
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
