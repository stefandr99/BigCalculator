namespace BigCalculator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service;
    using Validator;

    [ApiController]
    [Route("[controller]")]
    public class ComputeController : Controller
    {
        private readonly ICompute compute;
        private readonly Validator validator;

        public ComputeController(ICompute compute, Validator validator)
        {
            this.compute = compute;
            this.validator = validator;
        }

        [HttpGet("Compute")]
        //public string Pow([FromQuery] string a, [FromQuery] string b)
        //{
        //    return compute.Pow(a, b);
        //}

        // public string Sqrt([FromQuery] string[] a)
        // {
        //     return compute.Sqrt(a);
        // }

        [HttpGet("Validate")]
        public IActionResult Validate([FromQuery] string expression)
        {
            return this.FromResult(validator.Validate(expression));
        }

        //for testing the expression is given as a query string
        [HttpGet("Parse")]
        public IActionResult Parse([FromQuery] string expression)
        {

            var result = parser.MakePostfix(expression);

            return Ok(result);
        }

        /*[HttpPost("xml")]
        public IActionResult PostXml([FromBody] XElement myXml)
        {
            foreach (var element in myXml.Elements())
            {
                Console.WriteLine(element.Name.ToString());
            }
            //Console.WriteLine(myXml.ToString());
            return Ok();
        }*/

        [HttpPost("Compute")]
        public IActionResult PostXml([FromBody] string[] a, [FromBody] string[] b)
        {
            Console.WriteLine(compute.Sum(a, b));
            return Ok();
        }
    }
}
