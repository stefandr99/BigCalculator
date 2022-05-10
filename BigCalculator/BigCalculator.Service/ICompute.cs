namespace BigCalculator.Service
{
    public interface ICompute
    {
        Dictionary<string, string> ComputeCalculus(string expression, Dictionary<string, string> terms);

        string Sum(int[] a, int[] b);
        string Mul(int[] a, int[] b);
        string Diff(int[] a, int[] b);
        string Div(int[] a, int[] b);
        string Pow(int[] a, int[] b);
        string Sqrt(int[] a);

        List<int> FromDecimalToBinary(List<int> a);
        List<int> FromBinaryToDecimal(List<int> a);
        List<int> BinaryOr(List<int> a, List<int> b);
        int[] Div2(int[] a, int[] b);
    }
}
