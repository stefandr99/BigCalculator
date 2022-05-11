namespace BigCalculator.Service
{
    public interface IComparator
    {
        bool IsSmaller(int[] a, int[] b);

        bool IsSmallerOrEqual(string str1, string str2);

        bool AreEqual(string str1, string str2);
    }
}
