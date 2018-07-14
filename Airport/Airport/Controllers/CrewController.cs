using Abstractions.Bus;
using Airport.Contract.Command.Crew;
using Airport.Contract.Query.Crew;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Airport.Web.Controllers
{

    [Route("api/Crews")]
    public class CrewsController : Controller
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public CrewsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<CrewsQuery, CrewsResponse>(new CrewsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<CrewByIdQuery, CrewByIdResponse>(new CrewByIdQuery { CrewId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateCrewModel model)
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

            var command = new CreateCrewCommand
            {
                Id = id,
                StewardressesId=model.StewardessesId,
                PilotId=model.PilotId

            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateCrewModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<CrewByIdQuery, CrewByIdResponse>(new CrewByIdQuery { CrewId = model.Id });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateCrewCommand
            {
               StewardressesId=model.StewardessesId,
               PilotId=model.PilotId
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<CrewByIdQuery, CrewByIdResponse>(new CrewByIdQuery { CrewId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteCrewCommand { CrewId = id });
            return Ok();
        }
    }
}