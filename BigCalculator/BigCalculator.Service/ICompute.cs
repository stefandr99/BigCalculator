namespace BigCalculator.Service
{
    public interface ICompute
    {
        Dictionary<string, string> ComputeCalculus(string expression, Dictionary<string, string> terms);

        string Sum(string a, string b);
        string Mul(string a, string b);
        string Diff(string a, string b);
        string Div(int[] a, int[] b);
        string Pow(string a, string b);
        string Sqrt(string a);

    }
}
