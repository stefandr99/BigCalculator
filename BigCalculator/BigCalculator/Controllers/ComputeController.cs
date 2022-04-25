namespace BigCalculator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service;
    using Validator;
    using Parser;

    [ApiController]
    [Route("[controller]")]
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

        [HttpGet("Compute")]
        public int Compute([FromQuery] int a, [FromQuery] int b)
        {
            return compute.ComputeCalculus(a, b);
        }

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
    }
}
