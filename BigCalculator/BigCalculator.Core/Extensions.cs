namespace BigCalculator.Core
{
    using System.Diagnostics;
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

            Debug.Assert(terms.Count == data.Terms.Count(), "Data and terms list do not have equal length");

            return terms;
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
