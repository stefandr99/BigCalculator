using System.Collections;
using System.Text;

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
                    string operationResult = "0";

                    secondOperand = myStack.Pop().ToString();
                    firstOperand = myStack.Pop().ToString();

                    firstOperandValue = terms.ContainsKey(firstOperand) ? terms[firstOperand] : firstOperand;
                    secondOperandValue = terms.ContainsKey(secondOperand) ? terms[secondOperand] : secondOperand;
                    
                    operationResult = ComputeOperation(firstOperandValue, secondOperandValue, x);

                    Console.WriteLine("Operation " + counter + ":" + firstOperand + x + secondOperand + " = " + operationResult);
                    myStack.Push(operationResult);
                    counter++;
                }
            }
            var finalResult = myStack.Pop().ToString();
            return finalResult;
        }

        private string ComputeOperation(string firstOperand, string secondOperand, char operatorType)
        {
            string result = "0";

            switch (operatorType)
            {
                case '+':
                    result = Sum(firstOperand, secondOperand);
                    break;
                case '*':
                    result = Mul(firstOperand, secondOperand);
                    break;
            }
            return result;
        }

        public string Sum(string a, string b)
        {
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

            return sum.ToString();
        }

        public string Mul(string a, string b)
        {
            int len_a = a.Length;
            int len_b = b.Length;
            if (len_a == 0 || len_b == 0)
                return "0";

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
                return "0";

            String s = "";

            while (i >= 0)
                s += (result[i--]);

            return s;
        }

    }
}