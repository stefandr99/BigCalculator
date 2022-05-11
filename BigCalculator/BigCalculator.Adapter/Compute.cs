namespace BigCalculator.Adapter
{
    using System.Collections;
    using Calculus;
    using Core;
    using Service;

    public class Compute : ICompute
    {
        private readonly ICalculator calculator;
        private readonly IConvertor convertor;
        private readonly List<char> operators; 

        public Compute(IConvertor convertor, ICalculator calculator)
        {
            operators = new() { '+', '-', '*', '/', '^', '#' };
            this.convertor = convertor;
            this.calculator = calculator;
        }

        public Result<Dictionary<string, string>> ComputeCalculus(string expression, Dictionary<string, string> terms)
        {
            char x;
            string firstOperand, secondOperand, firstOperandValue, secondOperandValue, operationResult;
            int counter = 1;
            Dictionary<string, string> results = new Dictionary<string, string>();

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
                    if (x.Equals('#'))
                    {
                        firstOperand = myStack.Pop().ToString();

                        firstOperandValue = terms.ContainsKey(firstOperand) ? terms[firstOperand] : firstOperand;

                        operationResult = calculator.Sqrt(convertor.FromStringToIntArray(firstOperandValue));
                        results["operation " + counter] = "sqrt(" + firstOperand + ") =" + operationResult;
                    }
                    else
                    {
                        secondOperand = myStack.Pop().ToString();
                        firstOperand = myStack.Pop().ToString();

                        firstOperandValue = terms.ContainsKey(firstOperand) ? terms[firstOperand] : firstOperand;
                        secondOperandValue = terms.ContainsKey(secondOperand) ? terms[secondOperand] : secondOperand;

                        operationResult = ComputeOperation(firstOperandValue, secondOperandValue, x);

                        if (operationResult.Equals("-1"))
                        {
                            results["error"] = "Negative result of subsctraction: " + firstOperand + " " + x + " " + secondOperand;
                            return new InvalidResult<Dictionary<string, string>>(results["error"]);
                        }

                        results["operation " + counter] = firstOperand + " " + x + " " + secondOperand + " = " + operationResult;
                    }
                    myStack.Push(operationResult);
                    counter++;
                }
            }
            var finalResult = myStack.Pop().ToString();
            results["final result"] = finalResult;
            return new SuccessResult<Dictionary<string, string>>(results);
        }

        private string ComputeOperation(string firstOperand, string secondOperand, char operatorType)
        {
            string result = "0";

            int[] operand1 = convertor.FromStringToIntArray(firstOperand);
            int[] operand2 = convertor.FromStringToIntArray(secondOperand);

            switch (operatorType)
            {
                case '+':
                    result = calculator.Sum(operand1, operand2);
                    break;
                case '*':
                    result = calculator.Mul(operand1, operand2);
                    break;
                case '/':
                    result = calculator.Div(operand1, operand2);
                    break;
                case '-':
                    result = calculator.Diff(operand1, operand2);
                    break;
                case '^':
                    result = calculator.Pow(operand1, operand2);
                    break;
            }
            return result;
        }
    }
}