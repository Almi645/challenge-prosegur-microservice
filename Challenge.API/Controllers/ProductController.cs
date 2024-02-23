using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Challenge.Application.Queries.Product;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queryFilter = new ProductGetListQuery();
            var result = await mediator.Send(queryFilter);
            return Ok(result);
        }
    }
}
