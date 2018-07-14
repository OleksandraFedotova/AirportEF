using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Bus;
using Airport.Contract.Command.Departure;
using Airport.Contract.Query.Departure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Web.Controllers
{
    [Route("api/Departures")]
    public class DeparturesController : Controller
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public DeparturesController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<DeparturesQuery, DeparturesResponse>(new DeparturesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<DepartureByIdQuery, DepartureByIdResponse>(new DepartureByIdQuery { DepartureId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateDepartureModel model)
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

            var command = new CreateDepartureCommand
            {
                Id = id,
                AirCraftId = model.AirCraftId,
                FlightNumber = model.FlightNumber,
                CrewId = model.CrewId,
                DepartureDate = model.DepartureDate
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateDepartureModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<DepartureByIdQuery, DepartureByIdResponse>(new DepartureByIdQuery { DepartureId = model.DepartureId });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateDepartureCommand
            {
                AirCraftId=model.AirCraftId,
                FlightNumber=model.FlightNumber,
                CrewId=model.CrewId,
                DepartureDate=model.DepartureDate
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<DepartureByIdQuery, DepartureByIdResponse>(new DepartureByIdQuery { DepartureId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteDepartureCommand { DepartureId = id });
            return Ok();
        }
    }
}