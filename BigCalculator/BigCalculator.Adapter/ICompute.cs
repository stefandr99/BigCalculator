using BigCalculator.Core;

namespace BigCalculator.Adapter
{
    public interface ICompute
    {
        Result<Dictionary<string, string>> ComputeCalculus(string expression, Dictionary<string, string> terms);
    }
}
