namespace BigCalculator.Core
{
    using System.Text;
    using System.Xml.Linq;

    public static class Extensions
    {
        public static List<string> ToListTerms(this Data data)
        {
            List<string> terms = new();

            foreach (var term in data.Terms)

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

        public static string FromXmlToExpression(this XElement element)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var e in element.Elements())
            {
                if (e.Name == "parenthesis")
                {
                    sb.Append('(');
                    sb.Append(FromXmlToExpression(e));
                    sb.Append(')');
                }
                else
                {
                    sb.Append(e.Value);
                }
            }

            return sb.ToString();
        }

        public static Dictionary<string, string> FromDataTermsToDictionary(this Data data)
        {
            Dictionary<string, string> terms = new();

            foreach (var term in data.Terms)
            {
                terms.Add(term.Name, term.Value);
            }

            return terms;
        }
    }
}
