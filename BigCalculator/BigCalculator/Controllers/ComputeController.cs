namespace BigCalculator.Api.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Service;

    [ApiController]
    [Route("[controller]")]
    public class ComputeController
    {
        private readonly ICompute compute;

        public ComputeController(ICompute compute)
        {
            this.compute = compute;
        }

        [HttpGet("Compute")]
        public int Compute([FromQuery] int a, [FromQuery] int b)
        {
            return compute.ComputeCalculus(a, b);
        }
    }
}
