using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Repositories;
using MediatR;
using OneOf.Types;
using OneOf;
using Microsoft.Extensions.Caching.Memory;
using LazyCache;

namespace businesslogic.Features.ClinicFeatures
{
    public static class AvailableCities
    {
        public record Query() : IQueryRequest<IReadOnlyList<ClinicDto.Response.CityCode>>;

        public class Handler : IRequestHandler<Query, IReadOnlyList<ClinicDto.Response.CityCode>>
        {
            private readonly IClinicQueryRepository _repository;
            private readonly IAppCache _memoryCache;

            public Handler(IClinicQueryRepository repository, IAppCache memoryCache)
            {
                _repository = repository;
                _memoryCache = memoryCache;
            }

            public async Task<IReadOnlyList<ClinicDto.Response.CityCode>> Handle(Query request, CancellationToken cancellationToken)
            {
                Task<IReadOnlyList<ClinicDto.Response.CityCode>> availableCities() => _repository.GetAvailableCitiesAsync(cancellationToken);
                return await _memoryCache.GetOrAddAsync("AvailableCities", availableCities, TimeSpan.FromMinutes(5));
            }
        }
    }
}
