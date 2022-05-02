namespace BigCalculator.Core
{
    using System.Text;

    public static class Extensions
    {
        public static List<string> ToListTerms(this Data data)
        {
            List<string> terms = new();

            foreach (var term in data.terms)

            {
                terms.Add(term.Name);
            }

            return terms;
        }

        public static string GetIndexedTerm(this string expression, int index)
        {
            var term = new StringBuilder();

            while (Char.IsLetter(expression[index]))
            {
                term.Append(expression[index]);

                index--;
            }

            return new string(term.ToString().Reverse().ToArray());
        }
    }
}
