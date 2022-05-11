using BigCalculator.Core;
using System.Xml.Linq;

namespace BigCalculator.Service
{
    public interface IConvertor
    {
        Data XmlToData(XElement xml);

        List<Term> XmlToTerms(XElement xml);

        int[] FromStringToIntArray(string s);

        string FromIntArrayToString(int[] arr);
    }
}
