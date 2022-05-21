namespace BigCalculator.Calculus
{
    using System.Diagnostics;
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
            for (int it = 0; it < number.Length; it++)
            {
                Debug.Assert(number[it] >= 0, "Number has negative values");
                Debug.Assert(number[it].ToString().Length == 1, "Number has multiple values on individual fields");
            }

            int prevLength=number.Length;
            string res= string.IsNullOrEmpty(number) ? "" : number.Remove(number.Length - 1, 1);
            Debug.Assert(res.Length==prevLength-1 | res.Length == 0,"Length of number was not modified");
            return res;
        }

        public string Modulo10(string number)
        {
            for (int it = 0; it < number.Length; it++)
            {
                Debug.Assert(number[it] >= 0, "Number has negative values");
                Debug.Assert(number[it].ToString().Length == 1, "Number has multiple values on individual fields");
            }

            string res= string.IsNullOrEmpty(number) ? "" : number[number.Length - 1].ToString();
            Debug.Assert(res.Length == 1 | res.Length==0, "Returned more than 1 figure");
            return res;
        }
    }
}
