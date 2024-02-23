using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Challenge.Repository.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Challenge.Application.Queries.Product;
using Challenge.Repository.Base;
using Challenge.Application.Commands.Product;

namespace Challenge.API.Controllers
{
    [ApiController]
    [Route("product")]
    public class ProductController : ControllerBase
    {
        readonly IMediator mediator;

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

        [HttpPost]
        public async Task<IActionResult> Post(CreateProductCommand command)
        {
            await mediator.Send(command);
            return Ok(true);
        }
    }
}
