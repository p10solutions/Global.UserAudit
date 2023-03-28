using Microsoft.AspNetCore.Mvc;
using MediatR;
using Global.UserAudit.Api.Controllers.Base;
using Global.UserAudit.Application.Contracts.Notifications;
using Global.UserAudit.Application.Features.Users.Queries.GetUserById;
using Global.UserAudit.Application.Features.Users.Queries.GetUser;

namespace Global.UserAudit.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ApiControllerBase
    {
        public UserController(IMediator mediator, INotificationsHandler notificationsHandler) : base(mediator, notificationsHandler)
        {
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetUserResponse>))]
        public async Task<IActionResult> GetAsync()
            => await SendAsync(new GetUserQuery());

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetUserByIdResponse))]
        public async Task<IActionResult> GetAsync(Guid id)
            => await SendAsync(new GetUserByIdQuery(id));
    }
}