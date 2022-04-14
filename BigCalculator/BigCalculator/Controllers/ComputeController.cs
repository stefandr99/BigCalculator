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
        public int Compute([FromQuery] int a, [FromQuery] int b)
        {
            return compute.ComputeCalculus(a, b);
        }

        [HttpGet("Validate")]
        public IActionResult Validate([FromQuery] string expression)
        {
            return this.FromResult(validator.Validate(expression));
        }
    }
}
