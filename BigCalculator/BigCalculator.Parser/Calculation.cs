namespace BigCalculator.Calculus
{
    using System.Diagnostics;

    public class Calculation : ICalculation
    {
        public List<int> BinaryOr(List<int> a, List<int> b)
        {
            var distinctA = a.Distinct();
            Debug.Assert(distinctA.Count() is <= 2 and >= 0, "Binary number a contains values that are not 0 or 1");
            var distinctB = b.Distinct();
            Debug.Assert(distinctB.Count() is <= 2 and >= 0, "Binary number b contains values that are not 0 or 1");

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

            Debug.Assert(invA.Count(x => x == 1) >= a.Count(x => x == 1),
                "The number of 1s in the final array is lower than the first element");
            Debug.Assert(invA.Count(x => x == 1) >= b.Count(x => x == 1),
                "The number of 1s in the final array is lower than the second element");
            Debug.Assert(invA.Count == Math.Max(a.Count, b.Count),
                "The binary or result array length is not equal with the greatest array as parameter");

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
