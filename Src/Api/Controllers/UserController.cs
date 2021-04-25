using System;
using System.Threading.Tasks;
using Components.UserComponents.Commands;
using Components.UserComponents.Queries;
using Infrastructure.Commands;
using Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase
    {
        private readonly IQueryBus _queryBus;
        private readonly ICommandBus _commandBus;

        public UserController(IQueryBus queryBus, ICommandBus commandBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet, Route("{id}")]
        public async Task<ActionResult<GetUser.Result>> GetUser([FromRoute] Guid id)
        {
            var result = await _queryBus.Send(new GetUser.Query
            {
                UserId = id
            });

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<CreateUser.Result>> CreateUser([FromBody] CreateUser.Command user)
        {
            var result = await _commandBus.Send(user);
            
            return CreatedAtAction(nameof(GetUser), new { id = result.Id });
        }
    }
}