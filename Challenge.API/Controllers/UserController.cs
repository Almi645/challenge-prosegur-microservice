using Challenge.Application.Commands.Product;
using Challenge.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Challenge.API.Controllers
{
    [Route("user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<IActionResult> Auth(AuthenticateUserQuery query)
        {
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
