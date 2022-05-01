namespace BigCalculator.Service
{
    public interface ICompute
    {
        string ComputeCalculus(string expression, Dictionary<string,string> terms);

        string Sum(string a, string b);

        string Mul(string a, string b);

    }
}
