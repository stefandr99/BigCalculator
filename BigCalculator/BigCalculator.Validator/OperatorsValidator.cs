namespace BigCalculator.Validator
{
    using Core;

    public class OperatorsValidator : IValidator
    {
        private List<char> _operators = new List<char> { '+', '-', '*', '/', '^' };

        public Result<string> Validate(string expression)
        {
            if (_operators.Contains(expression.ElementAt(0)))
            {
                return new InvalidResult<string>("Wrong format!");
            }

            for (var i = 1; i < expression.Length - 1; i++)
            {
                if (_operators.Contains(expression.ElementAt(i)))
                {
                    if (_operators.Contains(expression.ElementAt(i - 1)) ||
                        _operators.Contains(expression.ElementAt(i + 1)))
                    {
                        return new InvalidResult<string>("Wrong format!");
                    }
                }

                if (expression.ElementAt(i) == '(')
                {
                    if (!_operators.Contains(expression.ElementAt(i - 1)) ||
                        !Char.IsDigit(expression.ElementAt(i + 1)))
                    {
                        return new InvalidResult<string>("Wrong format!");
                    }
                }

                if (expression.ElementAt(i) == ')')
                {
                    if (!_operators.Contains(expression.ElementAt(i + 1)) ||
                        !Char.IsDigit(expression.ElementAt(i - 1)))
                    {
                        return new InvalidResult<string>("Wrong format!");
                    }
                }
            }

            if (_operators.Contains(expression.ElementAt(expression.Length - 1)))
            {
                return new InvalidResult<string>("Wrong format!");
            }

            return new SuccessResult<string>("Success!");
        }
    }
}
