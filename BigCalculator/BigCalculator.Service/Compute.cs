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
            return "Nothing";
        }

        public string Mul(string a, string b)
        {
            return "Nothing";
        }

    }
}