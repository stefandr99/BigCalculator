namespace BigCalculator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service;
    using Validator;
    using Parser;
    using BigCalculator.Core;
    using System.Xml.Linq;
    using Newtonsoft.Json;

    [ApiController]
    [Route("")]
    public class ComputeController : Controller
    {
        private readonly ICompute compute;
        private readonly Validator validator;
        private readonly Parser parser;

        public ComputeController(ICompute compute, Validator validator, Parser parser)
        {
            this.compute = compute;
            this.validator = validator;
            this.parser = parser;
        }

        [HttpPost("Compute")]
        public IActionResult Compute([FromBody] Data data)
        {
            Dictionary<string, string> terms = new Dictionary<string, string>();

            foreach (var term in data.terms)
            {
                terms.Add(term.Name, term.Value);
            }

            var postfixExpression = parser.MakePostfix(data.Expression);

            var result = compute.ComputeCalculus(postfixExpression, terms);

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpPost("Validate")]
        public IActionResult Validate([FromBody] Data data)
        {
            return this.FromResult(validator.Validate(data));
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
    }
}
