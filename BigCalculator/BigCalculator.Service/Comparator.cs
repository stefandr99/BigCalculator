namespace BigCalculator.Service
{
    public class Comparator : IComparator
    {
        public bool IsSmaller(int[] a, int[] b)
        {
            int n1 = a.Length, n2 = b.Length;

            if (n1 < n2)
                return true;

            if (n2 < n1)
                return false;

            for (int i = 0; i < n1; i++)
                if (a[i] < b[i])
                    return true;
                else if (a[i] > b[i])
                    return false;

            return false;
        }

        public bool IsSmallerOrEqual(string str1, string str2)
        {
            int n1 = str1.Length, n2 = str2.Length;

            if (n1 < n2)
                return true;

            if (n2 < n1)
                return false;

            for (int i = 0; i < n1; i++)
                if (str1[i] < str2[i])
                    return true;
                else if (str1[i] > str2[i])
                    return false;

            return true;
        }

        public bool AreEqual(string str1, string str2)
        {
            int n1 = str1.Length, n2 = str2.Length;

            if (n1 < n2 || n2 < n1)
                return false;

            for (int i = 0; i < n1; i++)
                if (str1[i] < str2[i] || str1[i] > str2[i])
                    return false;

            return true;
        }
    }
}
