using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Bus;
using Airport.Contract.Command.Ticket;
using Airport.Contract.Query.Ticket;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Tickets")]
    public class TicketsController : Controller
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public TicketsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<TicketsQuery, TicketsResponse>(new TicketsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<TicketByIdQuery, TicketByIdResponse>(new TicketByIdQuery { TicketId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateTicketModel model)
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

            var command = new CreateTicketCommand
            {
                Id = id,
                FlightNumber = model.FlightNumber,
                Price = model.Price
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateTicketModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<TicketByIdQuery, TicketByIdResponse>(new TicketByIdQuery { TicketId = model.Id });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateTicketCommand
            {
                Id=model.Id,
                FlightNumber=model.FlightNumber,
                Price=model.Price
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<TicketByIdQuery, TicketByIdResponse>(new TicketByIdQuery { TicketId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteTicketCommand { TicketId = id });
            return Ok();
        }
    }
}