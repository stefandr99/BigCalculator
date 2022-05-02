using System.Xml.Serialization;

namespace BigCalculator.Core
{
    [Serializable, XmlRoot("data")]
    public class Data
    {
        public string Expression { get; set; }
        
        public IEnumerable<Term> Terms { get; set; }
    }
}
