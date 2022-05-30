namespace BigCalculator.Adapter
{
    using BigCalculator.Core;

    public interface ICompute
    {
        Result<Dictionary<string, string>> ComputeCalculus(string expression, Dictionary<string, string> terms);
    }
}
