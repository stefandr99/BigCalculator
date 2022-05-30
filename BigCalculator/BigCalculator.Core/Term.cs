namespace BigCalculator.Core
{
    using System.Xml.Serialization;

    [Serializable, XmlRoot("term")]
    public class Term
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("value")]
        public string Value { get; set; }

        public override bool Equals(object? obj)
        {
            Term other = obj as Term;

            return other.Name == Name && other.Value == Value;
        }
    }
}
