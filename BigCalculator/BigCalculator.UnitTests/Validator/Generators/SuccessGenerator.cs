namespace BigCalculator.UnitTests.Validator.Generators
{
    using System.Collections;
    using System.Collections.Generic;
    using BigCalculator.Core;
    using Core;

    public class SuccessGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+b*c+(b*c)*#(c)/(a+c)",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "c", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+(b*c)",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "c", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+b*c-#(c)*(#(b)-(b*c*a-(a-b)+c)+#(a)/c)",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "c", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+(b+c*(#(a)/#(b)+b+(a+c/(c+(a*#(a))))))",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "c", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "#(a+b*#(#(#(#(#(#(#(#(#(a*b/#(#(c)*a)*a)+a)*#(b))/c)/(a+c))/#(b*#(b))))-(a-c))))",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "c", Value = "10" },
                    }
                }
            };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
