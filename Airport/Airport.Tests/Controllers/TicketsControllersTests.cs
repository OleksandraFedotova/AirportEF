using Airport.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Airport.Tests.Controllers
{
    public class TicketsControllersTests
    {/*
        [Fact]
        public async Task Create_ReturnsNewlyCreatedIdeaForSession()
        {
           // Arrange
            int testSessionId = 123;
            string testName = "test name";
            string testDescription = "test description";
            var testSession = GetTestTickets();
            var mockRepo = new Mock<ITicketRepository>();
            mockRepo.Setup(repo => repo.GetById(testSessionId))
                .Returns(Task.FromResult(testSession));
            var controller = new TicketsController(mockRepo.Object);

            var newIdea = new NewIdeaModel()
            {
                Description = testDescription,
                Name = testName,
                SessionId = testSessionId
            };
            mockRepo.Setup(repo => repo.UpdateAsync(testSession))
                .Returns(Task.CompletedTask)
                .Verifiable();

            // Act
            var result = await controller.Create(newIdea);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnSession = Assert.IsType<BrainstormSession>(okResult.Value);
            mockRepo.Verify();
            Assert.Equal(2, returnSession.Ideas.Count());
            Assert.Equal(testName, returnSession.Ideas.LastOrDefault().Name);
            Assert.Equal(testDescription, returnSession.Ideas.LastOrDefault().Description);
        }
        */
        private List<Ticket> GetTestTickets()
        {
            var sessions = new List<Ticket>();
            sessions.Add(new Ticket()
            {
                Price = 14,
                FlightNumber = 16789,
                Id = Guid.NewGuid()
            });
            sessions.Add(new Ticket()
            {
                Price = 20,
                FlightNumber = 67890,
                Id = Guid.NewGuid()
            });

            return sessions;
        }
    }
}
