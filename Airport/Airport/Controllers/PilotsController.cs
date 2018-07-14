using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Bus;
using Airport.Contract.Command.Pilot;
using Airport.Contract.Query.Pilot;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Airport.Web.Controllers
{
    [Route("api/pilots")]
    public class PilotsController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public PilotsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<PilotsQuery, PilotsResponse>(new PilotsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<PilotByIdQuery, PilotByIdResponse>(new PilotByIdQuery { PilotId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePilotModel model)
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

            var command = new CreatePilotCommand
            {
                Id = id,
                DateOfBirth=model.DateOfBirth,
                FirstName=model.FirstName,
                LastName=model.LastName,
                Experience=model.Experience
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdatePilotModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<PilotByIdQuery, PilotByIdResponse>(new PilotByIdQuery { PilotId = model.PilotId });
            if (userToUpdate == null||model==null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdatePilotCommand
            {
                DateOfBirth = model.DateOfBirth,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Experience = model.Experience
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<PilotByIdQuery,PilotByIdResponse>(new PilotByIdQuery { PilotId=id});
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeletePilotCommand { PilotId=id});
            return Ok();
        }
    }
}
