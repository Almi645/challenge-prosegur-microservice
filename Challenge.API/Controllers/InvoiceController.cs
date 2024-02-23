using Challenge.Application.Commands.Invoice;
using Challenge.Application.Queries.Invoice;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Challenge.API.Controllers
{
    [Route("invoice")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IMediator mediator;

        public InvoiceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queryFilter = new InvoiceGetListQuery();
            var result = await mediator.Send(queryFilter);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post(GeneratedInvoiceCommand command)
        {
            await mediator.Send(command);
            return Ok(true);
        }
    }
}
