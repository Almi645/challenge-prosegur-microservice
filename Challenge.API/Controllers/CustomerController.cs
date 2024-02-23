using Challenge.Application.Queries.Customer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Challenge.API.Controllers
{
    [Route("customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queryFilter = new CustomerGetListQuery();
            var result = await mediator.Send(queryFilter);
            return Ok(result);
        }
    }
}
