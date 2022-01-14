using LocalizationAspNetAngular.Api.Features;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace LocalizationAspNetAngular.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GreetingController
    {
        private readonly IMediator _mediator;

        public GreetingController(IMediator mediator)
            => _mediator = mediator;

        [HttpGet(Name = "GetGreetingRoute")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetGreeting.Response), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetGreeting.Response>> Get([FromQuery] GetGreeting.Request request)
            => await _mediator.Send(request);
        
    }
}
