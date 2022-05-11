namespace BigCalculator.Calculus
{
    public interface ICalculator
    {
        string Sum(int[] a, int[] b);

        string Mul(int[] a, int[] b);

        string Diff(int[] a, int[] b);

        string Div(int[] a, int[] b);

        string Pow(int[] a, int[] b);

        string Sqrt(int[] a);
    }
}
