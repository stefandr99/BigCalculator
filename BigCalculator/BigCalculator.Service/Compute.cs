﻿using System.Text;

namespace BigCalculator.Service
{
    public class Compute : ICompute
    {
        private readonly List<char> operators = new List<char> { '+', '-', '*', '/' };

         public string ComputeCalculus(string expression, Dictionary<string, string> terms)
        {
            char x;
            string firstOperand, secondOperand, firstOperandValue, secondOperandValue;
            int counter = 1;

            Stack myStack = new Stack();
            Queue<char> postfixEpr = new Queue<char>();

            foreach (char c in expression)
            {
                postfixEpr.Enqueue(c);
            }

            while (postfixEpr.Count > 0)
            {
                x = postfixEpr.Dequeue();

                if (!operators.Contains(x))
                {
                    myStack.Push(x);
                }
                else
                {
                    secondOperand = myStack.Pop().ToString();
                    firstOperand = myStack.Pop().ToString();

                    firstOperandValue = terms.ContainsKey(firstOperand) ? terms[firstOperand] : firstOperand;
                    secondOperandValue = terms.ContainsKey(secondOperand) ? terms[secondOperand] : secondOperand;

                    string operationResult = ComputeOperation(firstOperandValue, secondOperandValue, x);
                    Console.WriteLine("Operation " + counter + ":" + firstOperand + x + secondOperand + " = " + operationResult);
                    myStack.Push(operationResult);
                    counter++;
                }
            }
            var finalResult = myStack.Pop().ToString();
            return finalResult;
        }

        private string ComputeOperation(string[] firstOperand, string secondOperand, char operatorType)
        {
            return a + b;
        }

        static bool isSmaller(string str1, string str2)
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

            return false;
        }

        static string ArrToString(string[] array)
        {
            
            return String.Join("", array);
        }
        static string[] StringToArr(string str)
        {
            return new[] { str };
        }
        public string[] Sum(string[] a_arr, string[] b_arr)
        {
            string a = ArrToString(a_arr);
            string b = ArrToString(b_arr);
			var sum = new StringBuilder();

			int carry = 0;

			if (a.Length != b.Length)
			{
				var maxLength = Math.Max(a.Length, b.Length);
				a = a.PadLeft(maxLength, '0');
				b = b.PadLeft(maxLength, '0');
			}

			for (int i = a.Length - 1; i >= 0; i--)
			{
				var digitSum = (a[i] - '0') + (b[i] - '0') + carry;

				if (digitSum > 9)
				{
					carry = 1;
					digitSum -= 10;
				}
				else
				{
					carry = 0;
				}

				sum.Insert(0, digitSum);
			}

			if (carry == 1)
				sum.Insert(0, carry);

			return StringToArr(sum.ToString());
		}

        public string[] Mul(string[] a_arr, string[] b_arr)
        {
            string a = ArrToString(a_arr);
            string b = ArrToString(b_arr);
            int len_a = a.Length;
            int len_b = b.Length;
            if (len_a == 0 || len_b == 0)
                return "0";   //aici trebuie sa fie aruncata o exceptie

            int[] result = new int[len_a + len_b];

            int last_a = 0;
            int last_b = 0;
            int i;

            for (i = len_a - 1; i >= 0; i--)
            {
                int carry = 0;
                int n1 = a[i] - '0';

                last_b = 0;
          
                for (int j = len_b - 1; j >= 0; j--)
                {
                    int n2 = b[j] - '0';

                    int sum = n1 * n2 + result[last_a + last_b] + carry;

                    carry = sum / 10;

                    result[last_a + last_b] = sum % 10;

                    last_b++;
                }

                if (carry > 0)
                    result[last_a + last_b] += carry;

                last_a++;
            }

            i = result.Length - 1;
            while (i >= 0 && result[i] == 0)
                i--;

            if (i == -1)
                return "0";  // aici trebuie sa fie aruncata o exceptie

            String s = "";

            while (i >= 0)
                s += (result[i--]);

            return StringToArr(s);
        }

        public string[] Diff(string[] a_arr, string[] b_arr)
        {
            string a = ArrToString(a_arr);
            string b = ArrToString(b_arr);
            if (isSmaller(a, b))
                return "-1"; // aici trebuie sa fie aruncata o exceptie

            string result = "";

            int len_a = a.Length;
            int len_b = b.Length;
            int diff = len_a - len_b;

            int carry = 0;

            for (int i = len_b - 1; i >= 0; i--)
            {
                int sub = (((int)a[i + diff] - (int)'0')
                           - ((int)b[i] - (int)'0') - carry);
                if (sub < 0)
                {
                    sub = sub + 10;
                    carry = 1;
                }
                else
                    carry = 0;

                result += sub.ToString();
            }

            for (int i = len_a - len_b - 1; i >= 0; i--)
            {
                if (a[i] == '0' && carry > 0)
                {
                    result += "9";
                    continue;
                }
                int sub = (((int)a[i] - (int)'0') - carry);
                if (i > 0 || sub > 0) 
                    result += sub.ToString();
                carry = 0;
            }

            char[] aa = result.ToCharArray();
            Array.Reverse(aa);
            return StringToArr(new string(aa));
        }

        public string[] Div(string[] a_arr, string[] b_arr)  
        {
            string a = ArrToString(a_arr);
            string b = ArrToString(b_arr);
            int b_int = 0;
            b_int = int.Parse(b);
            string res = "";
            int idx = 0;
            int temp = (int)(a[idx] - '0');
            while (temp < b_int)
            {
                temp = temp * 10 + (int)(a[idx + 1] - '0');
                idx++;
            }
            ++idx;

            while (a.Length > idx)
            {
                res += (char)(temp / b_int + '0');

                temp = (temp % b_int) * 10 + (int)(a[idx] - '0');
                idx++;
            }
            res += (char)(temp / b_int + '0');

            if (res.Length == 0)
                return "-1";  // aici trebuie sa fie aruncata o exceptie

            return StringToArr(res);

        }

        public string[] Pow(string[] a_arr, string[] b_arr)  
        {
            string a = ArrToString(a_arr);
            string b = ArrToString(b_arr);
            int a_int = int.Parse(a);
            int b_int = int.Parse(b);
            int[] res = new int[99999999];
            int i=1, k=1, j;
            res[1] = 1;

            while(i<= b_int)
            {
                for (j = 1; j <= k; j++)
                    res[j] = res[j] * a_int;
                for (j = 1; j < k; j++)
                {
                    res[j + 1] = res[j + 1] + res[j] / 10;
                    res[j] = res[j] % 10;
                }
                while( res[j] > 9)
                {
                    k++;
                    res[k] = res[k] + res[j] / 10;
                    res[k - 1] = res[k - 1] % 10;
                    j++;
                }
                i++;
            }

            string s = "";
            for (i = k; i >= 1; i--)
                s += res[i];

            return StringToArr(s);
        }

        public string[] Sqrt(string[] a_arr)
        {
            string a = ArrToString(a_arr);
            int a_int = int.Parse(a);
            int x = a_int;
            while (true)
            {
                int y = (x + a_int / x) / 2;
                if (y >= x)
                {
                    return StringToArr(x.ToString());
                }
                x = y;
            }
        }
    }
}