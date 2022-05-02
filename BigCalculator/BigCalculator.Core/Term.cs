using System.Xml.Serialization;

namespace BigCalculator.Core
{
    [Serializable, XmlRoot("term")]
    public class Term
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }
    }
}
