using Abstractions.Bus;
using Airport.Contract.Command.Stewardress;
using Airport.Contract.Query.Stewardess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Airport.Web.Controllers
{
    [Route("api/stewardesses")]
    public class StewardessesController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public StewardessesController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<StewardessesQuery, StewardessesResponse>(new StewardessesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<StewardessByIdQuery, StewardessByIdResponse>(new StewardessByIdQuery { StewardessId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateStewardessModel model)
        {

            if (model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var id = Guid.NewGuid();

            var command = new CreateStewardessCommand
            {
                Id = id,
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateStewardessModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<StewardessByIdQuery, StewardessByIdResponse>(new StewardessByIdQuery { StewardessId = model.Id });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateStewardressCommand
            {
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<StewardessByIdQuery, StewardessByIdResponse>(new StewardessByIdQuery { StewardessId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteStewardessCommand { StewardessId = id });
            return Ok();
        }
    }
}