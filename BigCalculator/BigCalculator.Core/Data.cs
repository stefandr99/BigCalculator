namespace BigCalculator.Core
{
    public class Data
    {
        public string Expression { get; set; }

        public IEnumerable<Term> terms { get; set; }
    }
}
