using Challenge.Application.Commands.OrderCommand;
using Challenge.Application.Queries.Order;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Challenge.API.Controllers
{
    [Route("order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        readonly IMediator mediator;

        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queryFilter = new OrderGetListQuery();
            var result = await mediator.Send(queryFilter);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType(typeof(IEnumerable<CreateOrderItemOuputCommand>), (int)HttpStatusCode.InternalServerError)]
        public async Task<IActionResult> Post(CreateOrderCommand command)
        {
            var result = await mediator.Send(command);

            if (result.Item1)
                return Ok(true);
            else
                return BadRequest(result.Item2);
        }
    }
}
