using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abstractions.Bus;
using Airport.Contract.Command.AirCraft;
using Airport.Contract.Query.AirCraft;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Airport.Web.Controllers
{
    [Route("api/AirCrafts")]
    public class AirCraftsController : Controller
    {
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public AirCraftsController(ICommandBus commandBus, IQueryBus queryBus)
        {
            _queryBus = queryBus;
            _commandBus = commandBus;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _queryBus.RequestAsync<AirCraftsQuery, AirCraftsResponse>(new AirCraftsQuery());

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var response = await _queryBus.RequestAsync<AirCraftByIdQuery, AirCraftByIdResponse>(new AirCraftByIdQuery { AirCraftId = id });

            if (response == null)
            {
                return BadRequest($"User {id} not found");
            }

            return Ok(response);
        }


        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateAirCraftModel model)
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

            var command = new CreateAirCraftCommand
            {
                Id = id,
                Name = model.Name,
                ReleaseDate = model.ReleaseDate,
                TimeSpan = model.TimeSpan,
                TypeId = model.TypeId
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody]UpdateAirCraftModel model)
        {
            var userToUpdate = _queryBus.RequestAsync<AirCraftByIdQuery, AirCraftByIdResponse>(new AirCraftByIdQuery { AirCraftId = model.AirCraftId });
            if (userToUpdate == null || model == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var command = new UpdateAirCraftCommand
            {
               Name=model.Name,
               ReleaseDate=model.ReleaseDate,
               TimeSpan=model.TimeSpan,
               TypeId=model.TypeId
            };

            await _commandBus.ExecuteAsync(command);

            return Ok();
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var model = _queryBus.RequestAsync<AirCraftByIdQuery, AirCraftByIdResponse>(new AirCraftByIdQuery { AirCraftId = id });
            if (model == null)
            {
                return BadRequest();
            }

            await _commandBus.ExecuteAsync(new DeleteAirCraftCommand { AirCraftId = id });
            return Ok();
        }
    }
}