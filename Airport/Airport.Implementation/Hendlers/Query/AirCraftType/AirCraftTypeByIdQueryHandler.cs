using Abstractions.CQRS;
using Airport.Contract.Query.AirCraft;
using Airport.Contract.Query.AirCraftType;
using Airport.Domain.Repositiories;
using AirPort.DataAccess;
using AutoMapper;
using System;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.AirCraftType
{
    public class AirCraftTypeByIdQueryHandler : IQueryHandler<AirCraftTypeByIdQuery, AirCraftTypeByIdResponse>
    {
        private readonly IAirCraftTypeRepository _airCraftTypeRepository;
        private readonly IMapper _mapper;

        public AirCraftTypeByIdQueryHandler(IAirCraftTypeRepository airCraftTypeRepository, IMapper mapper)
        {
            _airCraftTypeRepository = airCraftTypeRepository;
            _mapper = mapper;
        }

        public async Task<AirCraftTypeByIdResponse> ExecuteAsync(AirCraftTypeByIdQuery request)
        {
            var airCraftType = await _airCraftTypeRepository.GetById(request.AirCraftTypeId);

            if (airCraftType == null)
            {
                throw new Exception("Idea not found");
            }

            var mappedAirCraftType = _mapper.Map<AirCraftTypeByIdResponse>(airCraftType);

            return mappedAirCraftType;
        }
    }
}
