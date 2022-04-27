using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigCalculator.Core
{
    public class Data
    {
        public string Expression { get; set; }

        public IEnumerable<Term> terms { get; set; }
    }
}
