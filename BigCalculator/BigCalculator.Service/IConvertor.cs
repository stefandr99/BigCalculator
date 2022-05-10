using BigCalculator.Core;
using System.Xml.Linq;

namespace BigCalculator.Service
{
    public interface IConvertor
    {
        Data XmlToData(XElement xml);

        List<Term> XmlToTerms(XElement xml);

        List<int> FromDecimalToBinary(List<int> a);

        List<int> FromBinaryToDecimal(List<int> a);
    }
}
