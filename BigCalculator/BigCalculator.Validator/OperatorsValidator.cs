namespace BigCalculator.Validator
{
    using Core;
using System.Linq;

    public class OperatorsValidator : IValidator
    {
        private readonly List<char> _operators = new List<char> { '+', '-', '*', '/', '^' };

        public Result<string> Validate(Data data)
        {
            var terms = data.ToListTerms();

            if (_operators.Contains(data.Expression.ElementAt(0)))
            {
                return new InvalidResult<string>("Wrong format!");
            }

            for (var i = 1; i < data.Expression.Length - 1; i++)
            {
                if (_operators.Contains(data.Expression.ElementAt(i)))
                {
                    if (_operators.Contains(data.Expression.ElementAt(i - 1)) ||
                        _operators.Contains(data.Expression.ElementAt(i + 1)))
                    {
                        return new InvalidResult<string>("Wrong format!");
                    }
                }

                if (data.Expression.ElementAt(i) == '(')
                {
                    if (!_operators.Contains(data.Expression.ElementAt(i - 1)) ||
                        _operators.Contains(data.Expression.ElementAt(i + 1)))
                    {
                        return new InvalidResult<string>("Wrong format!");
                    }
                }

                if (data.Expression.ElementAt(i) == ')')
                {
                    if (!_operators.Contains(data.Expression.ElementAt(i + 1)) ||
                        _operators.Contains(data.Expression.ElementAt(i - 1)))
                    {
                        return new InvalidResult<string>("Wrong format!");
                    }
                }
            }

            if (_operators.Contains(data.Expression.ElementAt(data.Expression.Length - 1)))
            {
                return new InvalidResult<string>("Wrong format!");
            }

            return new SuccessResult<string>("Success!");
        }
    }
}
