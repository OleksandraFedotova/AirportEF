using Abstractions.CQRS;
using Airport.Contract.Query.Ticket;
using Airport.Domain.Repositiories;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.AirCraft
{
    public class TicketsQueryHandler : IQueryHandler<TicketsQuery, TicketsResponse>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public TicketsQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }

        public async Task<TicketsResponse> ExecuteAsync(TicketsQuery request)
        {
            var tickets = _ticketRepository.GetAll();

            if (tickets == null)
            {
                throw new Exception("Tickets not found");
            }

            var mappedAirCrafts = new TicketsResponse
            {
                Tickets = tickets.Select(_mapper.Map<Domain.Entities.Ticket, TicketsResponse.Ticket>).ToList()
            };

            return mappedAirCrafts;
        }
    }
}
