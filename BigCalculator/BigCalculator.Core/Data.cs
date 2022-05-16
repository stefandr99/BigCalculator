using System.Xml.Serialization;

namespace BigCalculator.Core
{
    [Serializable, XmlRoot("data")]
    public class Data
    {
        public string Expression { get; set; }
        
        public IEnumerable<Term> Terms { get; set; }

        public override bool Equals(object? obj)
        {
            var data = obj as Data;

            bool result = data.Expression == Expression;
            List<Term> terms = Terms.ToList();
            List<Term> dataTerms = data.Terms.ToList();

            for (int i = 0; i < Terms.Count(); i++)
            {
                result = result && terms[i].Equals(dataTerms[i]);
            }

            return result;
        }
    }
}
