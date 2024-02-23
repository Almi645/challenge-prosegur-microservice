using Challenge.Application.Queries.Province;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Challenge.API.Controllers
{
    [Route("province")]
    [ApiController]
    public class ProvinceController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProvinceController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var queryFilter = new ProvinceGetListQuery();
            var result = await mediator.Send(queryFilter);
            return Ok(result);
        }
    }
}
