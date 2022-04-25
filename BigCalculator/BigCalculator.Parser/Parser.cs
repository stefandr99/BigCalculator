using System.Collections;

namespace BigCalculator.Parser
{
    public class Parser
    {
        private Dictionary<char, int> operators = new Dictionary<char, int>
        {
            {'+', 1},
            {'-', 1},
            {'*', 2 },
            {'/', 2 },
            {'(', 3 },
            {')', 3 },
        };

        public String MakePostfix(String expression)
        {
            char x;

            Stack myStack = new Stack();
            Queue<char> originalExpression = new Queue<char>();
            Queue<char> postfixExpr = new Queue<char>();

            foreach (char c in expression)
            {
                originalExpression.Enqueue(c);
            }

            while (originalExpression.Count > 0)
            {
                x = originalExpression.Dequeue();

                if (!operators.ContainsKey(x))
                {
                    postfixExpr.Enqueue(x);
                }
                else
                {
                    if (x == ')')
                    {
                        while (!myStack.Peek().Equals('('))
                        {
                            postfixExpr.Enqueue((char)myStack.Pop());
                        }
                        myStack.Pop();
                    }
                    else
                    {
                        while (myStack.Count > 0 && !myStack.Peek().Equals('(') &&
                            operators[(char)myStack.Peek()] >= operators[x])
                        {
                            postfixExpr.Enqueue((char)myStack.Pop());
                        }
                        myStack.Push(x);
                    }
                }
            }
            while (myStack.Count > 0)
            {
                postfixExpr.Enqueue((char)myStack.Pop());
            }

            String result = new String(postfixExpr.ToArray());

            return result;
        }
    }
}