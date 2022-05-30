namespace BigCalculator.UnitTests.Validator.Generators
{
    using BigCalculator.Core;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TermsFailGenerator : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+b*c+(b*c)*#(c)/(a+c",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "d", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+b*c)",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                        new Term { Name = "b", Value = "10" },
                        new Term { Name = "a", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+b*c(a)+d",
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
                    Expression = "a+b*c(a+))",
                    Terms = new List<Term>
                    {
                        new Term { Name = "a", Value = "10" },
                    }
                }
            };

            yield return new object[]
            {
                new Data()
                {
                    Expression = "a+b*c-#(c)*#(b)-(b*c*a-(a-b)+c)+#(a*c*)/c)*e*z",
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
                    Expression = "b+b*c(b+b)",
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
