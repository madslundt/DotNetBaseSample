using System;
using System.Threading.Tasks;
using Components.UserComponents.Queries;
using Infrastructure.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IQueryBus _queryBus;

        public UserController(IQueryBus queryBus)
        {
            _queryBus = queryBus;
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
    }
}