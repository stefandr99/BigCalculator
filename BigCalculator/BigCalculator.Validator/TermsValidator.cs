namespace BigCalculator.Validator
{
    using Core;
    using System.Text.RegularExpressions;

    internal class TermsValidator : IValidator
    {
        public Result<string> Validate(Data data)
        {
            var terms = data.ToListTerms();
            var expressionTerms = Regex.Split(data.Expression, @"\W").ToList();

            expressionTerms.RemoveAll(x => x == "");

            foreach (var t in expressionTerms)
            {
                if (!terms.Contains(t))
                {
                    return new InvalidResult<string>("Invalid terms!");
                }
            }

            return new SuccessResult<string>("Success!");
        }
    }
}
