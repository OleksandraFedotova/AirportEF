using Abstractions.Bus;
using Airport.Contract.Command.Flight;
using Airport.Contract.Query.Flight;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Airport.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Flights")]
    public class FlightsController : Controller
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public FlightsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<FlightsQuery, FlightsResponse>(new FlightsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<FlightByIdQuery, FlightByIdResponse>(new FlightByIdQuery { FlightId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateFlightModel model)
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

            var command = new CreateFlightCommand
            {
                Id = id,
                DeparturePoint = model.DeparturePoint,
                DepartureTime = model.DepartureTime,
                Destination = model.Destination,
                Number = model.Number,
                TicketsId = model.TicketsId,
                TimeOfArrival = model.TimeOfArrival
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateFlightModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<FlightByIdQuery, FlightByIdResponse>(new FlightByIdQuery { FlightId = model.FlightId });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateFlightCommand
            {
                DeparturePoint=model.DeparturePoint,
                DepartureTime=model.DepartureTime,
                FlightId=model.FlightId,
                Destination=model.Destination,
                Number=model.Number,
                TicketsId=model.TicketsId,
                TimeOfArrival=model.TimeOfArrival
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<FlightByIdQuery, FlightByIdResponse>(new FlightByIdQuery { FlightId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteFlightCommand { FlightId = id });
            return Ok();
        }
    }
}