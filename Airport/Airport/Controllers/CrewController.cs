using Abstractions.Bus;
using Airport.Contract.Command.Crew;
using Airport.Contract.Command.Pilot;
using Airport.Contract.Command.Stewardress;
using Airport.Contract.Query.Crew;
using Airport.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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

        [HttpGet]
        public async Task<IActionResult> GetCrewsFromAPI()
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string json = await client.GetStringAsync("http://5b128555d50a5c0014ef1204.mockapi.io/crew");
            List<TenCrewsModel> data = JsonConvert.DeserializeObject<List<TenCrewsModel>>(json);
            List<TenCrewsModel> tenCrew = data.Where(c => c.Id < 11).ToList();

            //Changing int Id to Guid because my DB is working with them.
            var crewTasks = new List<Task>();
            foreach (var crew in tenCrew)
            {
                var StewardessesId = new List<Guid>();
                var stTasks = new List<Task>();
                foreach (var stewardess in crew.Stewardess)
                {
                    var stewardessId = Guid.NewGuid();
                    var c = new CreateStewardessCommand
                    {
                        Id = stewardessId,
                        DateOfBirth = stewardess.BirthDate,
                        FirstName = stewardess.FirstName,
                        LastName = stewardess.LastName
                    };
                    stTasks.Add(_commandBus.ExecuteAsync(c));

                    StewardessesId.Add(stewardessId);
                }
                await Task.WhenAll(stTasks);
                var pilot = crew.Pilot.First();
                var pilotId = Guid.NewGuid();
                var command = new CreatePilotCommand
                {
                    Id = pilotId,
                    FirstName = pilot.FirstName,
                    LastName = pilot.LastName,
                    Experience = pilot.Exp,
                    DateOfBirth = pilot.BirthDate
                };

                await _commandBus.ExecuteAsync(command);


                var createCrewCommand = new CreateCrewCommand
                {
                    Id = Guid.NewGuid(),
                    PilotId = pilotId,
                    StewardressesId = StewardessesId
                };

                crewTasks.Add(_commandBus.ExecuteAsync(createCrewCommand));

            }

            await Task.WhenAll(crewTasks);

            return Ok(json);
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
                StewardressesId = model.StewardessesId,
                PilotId = model.PilotId

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
                StewardressesId = model.StewardessesId,
                PilotId = model.PilotId
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