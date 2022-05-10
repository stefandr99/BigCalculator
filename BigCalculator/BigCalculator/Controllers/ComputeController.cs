namespace BigCalculator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service;
    using Validator;
    using Parser;
    using Core;
    using System.Xml.Linq;
    using Newtonsoft.Json;

    [ApiController]
    [Route("")]
    public class ComputeController : Controller
    {
        private readonly ICompute compute;
        private readonly Validator validator;
        private readonly Parser parser;
        private readonly Convertor convertor;

        public ComputeController(ICompute compute, Validator validator, Parser parser, Convertor convertor)
        {
            this.compute = compute;
            this.validator = validator;
            this.parser = parser;
            this.convertor = convertor;
        }

        [HttpPost("Compute")]
        public IActionResult Compute([FromBody] Data data)
        {
            var terms = data.FromDataTermsToDictionary();

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

        [HttpPost("ComputeXml")]
        public IActionResult PostXml([FromBody] XElement xml)
        {
            var data = convertor.XmlToData(xml);

            var terms = data.FromDataTermsToDictionary();

            var postfixExpression = parser.MakePostfix(data.Expression);

            var result = compute.ComputeCalculus(postfixExpression, terms);

            return Ok(JsonConvert.SerializeObject(result));
        }

        [HttpPost("Test")]
        public IActionResult Test(int[] a)
        {
            var result = compute.FromDecimalToBinary(a);

            return Ok(result);
        }

        [HttpPost("Test2")]
        public IActionResult Test([FromBody] Num num)
        {
            var result = compute.Div2(num.a, num.b);

            return Ok(result);
        }
    }

    public class Num
    {
        public int[] a { get; set; }

        public int[] b { get; set; }
    }
}
