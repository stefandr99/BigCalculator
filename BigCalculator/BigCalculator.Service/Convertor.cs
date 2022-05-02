namespace BigCalculator.Service
{
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using Core;

    public class Convertor
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

        private List<Term> XmlToTerms(XElement xml)
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
    }
}
