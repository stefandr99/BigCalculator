namespace BigCalculator.Calculus
{
    using Service;
    using System.Diagnostics;

    public class Calculator : ICalculator
    {
        private readonly IComparator comparator;
        private readonly IConvertor convertor;
        private readonly ICalculation calculation;

        public Calculator(IComparator comparator, IConvertor convertor, ICalculation calculation)
        {
            this.comparator = comparator;
            this.convertor = convertor;
            this.calculation = calculation;
        }

        public string Sum(int[] a, int[] b)
        {
            Debug.Assert((a.Length > 1 ? a[0] > 0 : a[0] >= 0) && a[0].ToString().Length == 1, "First digit of first operand not valid");
            Debug.Assert((b.Length > 1 ? b[0] > 0 : b[0] >= 0) && b[0].ToString().Length == 1, "First digit of second operand not valid");

            for (int i = 1; i < a.Length; i++)
            {
                Debug.Assert(a[i] >= 0, "First operand has negative values");
                Debug.Assert(a[i].ToString().Length == 1, "First operator has multiple values on individual fields");
            }

            for (int i = 1; i < b.Length; i++)
            {
                Debug.Assert(b[i] >= 0, "Second operand has negative values");
                Debug.Assert(b[i].ToString().Length == 1, "Second operand has multiple values on individual fields");
            }

            Array.Reverse(a);
            Array.Reverse(b);

            int maxLength = Math.Max(a.Length, b.Length);

            int[] result = new int[maxLength + 1];

            int lhs = 0, rhs = 0, sum = 0, carry = 0;

            Debug.Assert(result[0] == (lhs + rhs + carry) % 10);
            for (int i = 0; i < maxLength; i++)
            {
                Debug.Assert(maxLength - i > 0); //variant
                Debug.Assert(result[i] >= 0, "Digit of result is negative"); //invariant

                lhs = (i < a.Length) ? a[i] : 0;
                rhs = (i < b.Length) ? b[i] : 0;

                sum = result[i] + lhs + rhs;
                result[i] = sum % 10;

                Debug.Assert(result[i] == (lhs + rhs + carry) % 10);

                carry = sum / 10;
                result[i + 1] = result[i + 1] + carry;
            }

            int j = result.Length - 1;
            if (result[j] == 0)
                j--;

            String s = "";

            while (j >= 0)
            {
                Debug.Assert(j >= 0); //variant
                s += (result[j--]);
            }

            Debug.Assert(s.Length >= maxLength, "Length of the result is shorter than expected");
            Debug.Assert(s.All(char.IsDigit), "Result contains negative values");
            return s;
        }

        public string Mul(int[] a, int[] b)
        {
            Debug.Assert((a.Length > 1 ? a[0] > 0 : a[0] >= 0) && a[0].ToString().Length == 1, "First digit of first operand not valid");
            Debug.Assert((b.Length > 1 ? b[0] > 0 : b[0] >= 0) && b[0].ToString().Length == 1, "First digit of second operand not valid");

            for (int j = 1; j < a.Length; j++)
            {
                Debug.Assert(a[j] >= 0, "First operand has negative values");
                Debug.Assert(a[j].ToString().Length == 1, "First operator has multiple values on individual fields");
            }

            for (int j = 1; j < b.Length; j++)
            {
                Debug.Assert(b[j] >= 0, "Second operand has negative values");
                Debug.Assert(b[j].ToString().Length == 1, "Second operand has multiple values on individual fields");
            }

            int lenA = a.Length;
            int lenB = b.Length;
            if (a[0] == 0 || b[0] == 0)
                return "0";

            int[] result = new int[a.Length + b.Length];
            int lastA = 0;
            int i, sum = 0, carry;

            for (i = lenA - 1; i >= 0; i--)
            {
                Debug.Assert(i >= 0);
                
                carry = 0;
                int n1 = a[i];
                var lastB = 0;

                for (int j = lenB - 1; j >= 0; j--)
                {
                    Debug.Assert(i >= 0);
                    Debug.Assert(result[lastA + lastB].ToString().Length == 1);

                    int n2 = b[j];

                    sum = n1 * n2 + result[lastA + lastB] + carry;

                    carry = sum / 10;

                    result[lastA + lastB] = sum % 10;

                    lastB++;
                }

                if (carry > 0)
                    result[lastA + lastB] += carry;

                lastA++;
            }

            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;

            String s = "";

            while (i >= 0)
                s += (result[i--]);

            Debug.Assert(s.Length >= Math.Max(a.Length, b.Length), "Result of multiplication is shorter than the operands");
            Debug.Assert(s.All(char.IsDigit), "Result contains negative values");
            return s;
        }

        public string Diff(int[] a, int[] b)
        {
            Debug.Assert((a.Length > 1 ? a[0] > 0 : a[0] >= 0) && a[0].ToString().Length == 1, "First digit of first operand not valid");
            Debug.Assert((b.Length > 1 ? b[0] > 0 : b[0] >= 0) && b[0].ToString().Length == 1, "First digit of second operand not valid");

            for (int j = 1; j < a.Length; j++)
            {
                Debug.Assert(a[j] >= 0, "First operand has negative values");
                Debug.Assert(a[j].ToString().Length == 1, "First operator has multiple values on individual fields");
            }

            for (int j = 1; j < b.Length; j++)
            {
                Debug.Assert(b[j] >= 0, "Second operand has negative values");
                Debug.Assert(b[j].ToString().Length == 1, "Second operand has multiple values on individual fields");
            }

            if (comparator.IsSmaller(a, b))
                return "-1";

            string result = "";

            int lenA = a.Length;
            int lenB = b.Length;
            int diff = lenA - lenB;

            int carry = 0;

            for (int i = lenB - 1; i >= 0; i--)
            {
                int sub = a[i + diff] - b[i] - carry;
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result += sub.ToString();
            }

            for (int i = lenA - lenB - 1; i >= 0; i--)
            {
                if (a[i] == 0 && carry > 0)
                {
                    result += "9";
                    continue;
                }
                int sub = a[i] - carry;
                if (i >= 0 || sub > 0)
                    result += sub.ToString();
                carry = 0;
            }


            Debug.Assert(result.Length <= Math.Max(a.Length, b.Length), "Diff is larger than the operands");
            Debug.Assert(result.All(char.IsDigit), "Result contains negative values");
            char[] resultAsArray = result.ToCharArray();
            Array.Reverse(resultAsArray);
            var resultToReturn = new string(resultAsArray).TrimStart('0');
            return string.IsNullOrEmpty(resultToReturn) ? "0" : resultToReturn;
        }

        public string Div(int[] a, int[] b)
        {
            Debug.Assert((a.Length > 1 ? a[0] > 0 : a[0] >= 0) && a[0].ToString().Length == 1, "First digit of first operand not valid");
            Debug.Assert((b.Length > 1 ? b[0] > 0 : b[0] > 0) && a[0].ToString().Length == 1, "Divisior not valid");

            for (int j = 1; j < a.Length; j++)
            {
                Debug.Assert(a[j] >= 0, "First operand has negative values");
                Debug.Assert(a[j].ToString().Length == 1, "First operator has multiple values on individual fields");
            }

            for (int j = 1; j < b.Length; j++)
            {
                Debug.Assert(b[j] >= 0, "Second operand has negative values");
                Debug.Assert(b[j].ToString().Length == 1, "Second operand has multiple values on individual fields");
            }

            var denom = b.ToList();
            var current = new List<int>();
            var answer = new List<int>();
            current.Add(1);
            answer.Add(0);

            if (b[0] == 0)
            {
                return "-2";
            }

            if (comparator.IsSmaller(a, b))
            {
                return "0";
            }

            if (comparator.AreEqual(convertor.FromIntArrayToString(a), convertor.FromIntArrayToString(b)))
            {
                return "1";
            }

            var denomBin = FromDecimalToBinary(denom);
            var currentBin = FromDecimalToBinary(current);

            while (comparator.IsSmallerOrEqual(convertor.FromIntArrayToString(denom.ToArray()), convertor.FromIntArrayToString(a)))
            {
                denomBin.Add(0);
                currentBin.Add(0);

                denom = FromBinaryToDecimal(denomBin);
            }

            denomBin.RemoveAt(denomBin.Count - 1);
            currentBin.RemoveAt(currentBin.Count - 1);

            denom = FromBinaryToDecimal(denomBin);
            var answerBin = FromDecimalToBinary(answer);

            while (currentBin.Count > 0)
            {
                if (comparator.IsSmallerOrEqual(convertor.FromIntArrayToString(denom.ToArray()), convertor.FromIntArrayToString(a)))
                {
                    var res = Diff(a, denom.ToArray());
                    a = convertor.FromStringToIntArray(res);

                    answerBin = calculation.BinaryOr(answerBin, currentBin);
                }

                denomBin.RemoveAt(denomBin.Count - 1);
                currentBin.RemoveAt(currentBin.Count - 1);

                denom = FromBinaryToDecimal(denomBin);
            }

            var arrayResult = FromBinaryToDecimal(answerBin).ToArray();
            // TODO: Check if div is positive
            return convertor.FromIntArrayToString(arrayResult);
        }

        public string Pow(int[] a, int[] b)
        {
            Debug.Assert((a.Length > 1 ? a[0] > 0 : a[0] >= 0) && a[0].ToString().Length == 1, "First digit of first operand not valid");
            Debug.Assert((b.Length > 1 ? b[0] > 0 : b[0] >= 0) && b[0].ToString().Length == 1, "First digit of second operand not valid");

            for (int it = 0; it < a.Length; it++)
            {
                Debug.Assert(a[it] >= 0, "First operand has negative values");
                Debug.Assert(a[it].ToString().Length == 1, "First operator has multiple values on individual fields");
            }

            for (int it = 0; it < b.Length; it++)
            {
                Debug.Assert(b[it] >= 0, "Second operand has negative values");
                Debug.Assert(b[it].ToString().Length == 1, "Second operand has multiple values on individual fields");
            }

            string[] res = new string[99999999];
            int[] i = new int[b.Length];
            int j, k = 1;

            res[1] = "1";

            while (comparator.IsSmaller(i, b))
            {
                for (j = 1; j <= k; j++)
                {
                    var operand = convertor.FromStringToIntArray(res[j]);
                    res[j] = Mul(operand, a);
                }

                for (j = 1; j < k; j++)
                {
                    var operand1 = convertor.FromStringToIntArray(res[j + 1]);
                    var operand2 = calculation.DivideBy10(res[j]);
                    res[j + 1] = Sum(operand1, convertor.FromStringToIntArray(operand2));
                    res[j] = calculation.Modulo10(res[j]);
                }
                while (res[j].Length > 1)
                {
                    k++;
                    var operand1 = convertor.FromStringToIntArray(res[k]);
                    var operand2 = calculation.DivideBy10(res[j]);
                    res[k] = Sum(operand1, convertor.FromStringToIntArray(operand2));
                    res[k - 1] = calculation.Modulo10(res[k - 1]);
                    j++;
                }
                i = convertor.FromStringToIntArray(Sum(i, new[] { 1 }));
            }
            string result = "";
            for (j = k; j >= 1; j--)
                result += res[j];

            Debug.Assert(result.Length >= Math.Max(a.Length, b.Length), "Sum is shorter than the operands");
            Debug.Assert(result.All(char.IsDigit), "Result contains negative values");
            return result;
        }

        public string Sqrt(int[] a)
        {
            Debug.Assert((a.Length > 1 ? a[0] > 0 : a[0] >= 0) && a[0].ToString().Length == 1, "First digit of operand not valid");
            
            for (int it = 0; it < a.Length; it++)
            {
                Debug.Assert(a[it] >= 0, "First operand has negative values");
                Debug.Assert(a[it].ToString().Length == 1, "First operator has multiple values on individual fields");
            }

            if (a[0] < 0)
            {
                return "-1";
            }

            int[] res = new int[] { 0 };
            int[] one = new int[] { 1 };

            while (comparator.IsSmaller(convertor.FromStringToIntArray(Mul(res, res)), a))
            {
                string result = Sum(res, one);
                res = convertor.FromStringToIntArray(result);
            }

            if (Mul(res, res).Equals(convertor.FromIntArrayToString(a)))
                return convertor.FromIntArrayToString(res);

            string final = Diff(res, one);
            Debug.Assert(final.All(char.IsDigit), "Result contains negative values");
            return final;
        }

        public List<int> FromDecimalToBinary(List<int> a)
        {
            for (int it = 0; it < a.Count; it++)
            {
                Debug.Assert(a[it] >= 0, "Number has negative values");
                Debug.Assert(a[it].ToString().Length == 1, "Number has multiple values on individual fields");
            }

            if (a[0] < 0)
            {
                return new() { -1 };
            }

            var bin = new List<int>();
            var twoPow = new List<string> { "1" };
            var b = new[] { 1 };
            var two = new[] { 2 };

            if ((a.Count == 1 && a[0] == 0) || a.Count == 0)
            {
                bin.Add(0);

                return bin;
            }

            while (comparator.IsSmallerOrEqual(convertor.FromIntArrayToString(b), convertor.FromIntArrayToString(a.ToArray())))
            {
                var res = Mul(b, two);
                twoPow.Add(res);
                b = convertor.FromStringToIntArray(res);
            }

            twoPow.RemoveAt(twoPow.Count - 1);
            twoPow.Reverse();

            foreach (var pow in twoPow)
            {
                var aStr = convertor.FromIntArrayToString(a.ToArray());

                if (comparator.IsSmallerOrEqual(pow, aStr))
                {
                    var res = Diff(a.ToArray(), convertor.FromStringToIntArray(pow));
                    a = convertor.FromStringToIntArray(res).ToList();
                    bin.Add(1);
                }
                else
                {
                    bin.Add(0);
                }
            }
            Debug.Assert(bin.Distinct().Count() > 2, "Binary conversion contains values that are not 0 or 1");

            return bin;
        }

        public List<int> FromBinaryToDecimal(List<int> a)
        {
            Debug.Assert(a.Distinct().Count() > 2, "Binary number contains values that are not 0 or 1");

            if (a.Distinct().Count() > 2)
            {
                return new() { -1 };
            }

            var pow = new[] { 1 };
            var two = new[] { 2 };
            var result = new[] { 0 };
            var aReverse = a.ToArray().Reverse();

            foreach (var bit in aReverse)
            {
                if (bit == 1)
                {
                    var res = Sum(result, pow);
                    Array.Reverse(result);
                    Array.Reverse(pow);
                    result = convertor.FromStringToIntArray(res);
                }

                var powStr = Mul(pow, two);
                pow = convertor.FromStringToIntArray(powStr);
            }

            for (int it = 0; it < a.Count; it++)
            {
                Debug.Assert(result[it] >= 0, "Result has negative values");
                Debug.Assert(result[it].ToString().Length == 1, "Result has multiple values on individual fields");
            }

            return result.ToList();
        }
    }
}
