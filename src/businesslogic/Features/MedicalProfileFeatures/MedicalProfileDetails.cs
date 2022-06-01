using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using MediatR;
using System.Threading;
using businesslogic.abstraction.Contracts;
using datalayer.abstraction.Repositories;
using datalayer.abstraction.Entities;
using OneOf.Types;
using OneOf;
using System.Collections.Generic;

namespace businesslogic.Features.MedicalProfileFeatures
{
    public static class MedicalProfileDetails
    {
        public record Query(string City) : IQueryRequest<IReadOnlyList<MedicalProfileDto.Response.Details>>;
        
        public class Handler : IRequestHandler<Query, IReadOnlyList<MedicalProfileDto.Response.Details>>
        {
            private readonly IMedicalProfileQueryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IMedicalProfileQueryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<MedicalProfileDto.Response.Details>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetListAsync(request.City, cancellationToken);

                return _mapper.Map<IReadOnlyList<(MedicalProfile, int doctorsCount)>, IReadOnlyList<MedicalProfileDto.Response.Details>>(result);
            }
        }
    }
}
