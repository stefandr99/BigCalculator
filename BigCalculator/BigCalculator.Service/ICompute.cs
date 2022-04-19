namespace BigCalculator.Service
{
    public interface ICompute
    {
        int ComputeCalculus(int a, int b);

        string Sum(string a, string b);
        string Mul(string a, string b);
        string Diff(string a, string b);
        string Div(string a, int b);
        string Pow(string a, string b);
    }
}
