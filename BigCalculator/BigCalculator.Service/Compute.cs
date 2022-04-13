namespace BigCalculator.Service
{
    public class Compute : ICompute
    {
        public int ComputeCalculus(int a, int b)
        {
            return a + b;
        }

        public int Sum(int a, int b)
        {
            return a + b;
        }

        public int Diff(int a, int b)
        {
            return a - b;
        }
    }
}