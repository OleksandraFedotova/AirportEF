using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Bus;
using Airport.Contract.Command.AirCraftType;
using Airport.Contract.Query.AirCraft;
using Airport.Contract.Query.AirCraftType;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/AirCraftTypes")]
    public class AirCraftTypesController : Controller
    {

        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public AirCraftTypesController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<AirCraftTypesQuery, AirCraftTypesResponse>(new AirCraftTypesQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<AirCraftTypeByIdQuery, AirCraftTypeByIdResponse>(new AirCraftTypeByIdQuery { AirCraftTypeId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateAirCraftTypeModel model)
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

            var command = new CreateAirCraftTypeCommand
            {
                Id = id,
                LoadCapacity = model.LoadCapacity,
                Model = model.Model,
                Seats = model.Seats
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateAirCraftTypeModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<AirCraftTypeByIdQuery, AirCraftTypeByIdResponse>(new AirCraftTypeByIdQuery { AirCraftTypeId = model.AirCraftTypeId });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateAirCraftTypeCommand
            {
                LoadCapacity = model.LoadCapacity,
                Model = model.Model,
                Seats = model.Seats
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<AirCraftTypeByIdQuery, AirCraftTypeByIdResponse>(new AirCraftTypeByIdQuery { AirCraftTypeId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteAirCraftTypeCommand { AirCraftTypeId = id });
            return Ok();
        }
    }
}