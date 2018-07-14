using Abstractions.CQRS;
using Airport.Contract.Query.AirCraftType;
using Airport.Domain.Repositiories;
using AutoMapper;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Airport.Implementation.Hendlers.Query.AirCraftType
{
    public class AirCraftTypesQueryHandler : IQueryHandler<AirCraftTypesQuery, AirCraftTypesResponse>
    {
        private readonly IAirCraftTypeRepository _airCraftTypeRepository;
        private readonly IMapper _mapper;

        public AirCraftTypesQueryHandler(IAirCraftTypeRepository airCraftTypeRepository, IMapper mapper)
        {
            _airCraftTypeRepository = airCraftTypeRepository;
            _mapper = mapper;
        }

        public async Task<AirCraftTypesResponse> ExecuteAsync(AirCraftTypesQuery request)
        {
            var types = _airCraftTypeRepository.GetAll();

            if (types == null)
            {
                throw new Exception("AirCraftTypes not found");
            }
            try
            {
                var mappedAirCraftTypes = new AirCraftTypesResponse
                {
                    AirCraftTypes = types.Select(_mapper.Map<Domain.Entities.AirCraftType, AirCraftTypesResponse.AirCraftType>).ToList()
                };

                return mappedAirCraftTypes;
            }
            catch(Exception e)
            {

            }
            return null;
        }
    }
}
