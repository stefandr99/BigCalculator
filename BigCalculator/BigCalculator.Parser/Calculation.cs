namespace BigCalculator.Calculus
{
    public class Calculation : ICalculation
    {
        public List<int> BinaryOr(List<int> a, List<int> b)
        {
            var len = a.Count > b.Count ? b.Count : a.Count;
            int i;

            var invA = a.ToArray().Reverse().ToList();
            var invB = b.ToArray().Reverse().ToList();

            for (i = 0; i < len; i++)
            {
                invA[i] = invA[i] | invB[i];
            }

            if (a.Count < b.Count)
            {
                while (i < b.Count)
                {
                    invA.Add(invB[i]);
                    i++;
                }
            }

            return invA.ToArray().Reverse().ToList();
        }

        public string DivideBy10(string number)
        {
            return number.Remove(number.Length - 1, 1);
        }

        public string Modulo10(string number)
        {
            return number[number.Length - 1].ToString();
        }
    }
}
