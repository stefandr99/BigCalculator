namespace BigCalculator.Service
{
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Diagnostics;
    using Core;

    public class Convertor : IConvertor
    {
        public Data XmlToData(XElement xml)
        {
            Data data = new Data();
            var expression = xml.Elements().ToList()[0];

            var result = expression.FromXmlToExpression(); 
            
            data.Expression = result;
            data.Terms = XmlToTerms(xml);

            return data;
        }

        public List<Term> XmlToTerms(XElement xml)
        {
            List<Term> terms = new List<Term>();
            var ser = new XmlSerializer(typeof(Term));

            foreach (var t in xml.Elements().ToList()[1].Elements())
            {
                var reader = t.CreateReader();
                var r = (Term)ser.Deserialize(reader);
                terms.Add(r);
            }

            return terms;
        }

        public int[] FromStringToIntArray(string s)
        {
            int[] result = new int[] { 0 };

            if (!String.IsNullOrEmpty(s))
            {
                result = Array.ConvertAll(s.ToCharArray(), c => (int)char.GetNumericValue(c));
            }

            Debug.Assert(!String.IsNullOrEmpty(s) ? s.Length == result.Count() : result.Length == 1, "Numbers don't have equal lengths");
            return result;
        }

        public string FromIntArrayToString(int[] arr)
        {
            if (arr != null)
            {
                var result=string.Join(string.Empty, arr);
                Debug.Assert(arr.Length == result.Count(), "Numbers don't have equal lengths");
                return result;
            }

            return "-1";
        }
    }
}
