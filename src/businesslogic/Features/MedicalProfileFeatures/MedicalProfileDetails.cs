using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using MediatR;
using System.Threading;
using businesslogic.abstraction.Contracts;
using datalayer.abstraction.Repositories;
using datalayer.abstraction.Entities;
using OneOf.Types;
using OneOf;

namespace businesslogic.Features.MedicalProfileFeatures
{
    public static class MedicalProfileDetails
    {
        public record Query(long Id) : IQueryRequest<OneOf<MedicalProfileDto.Response.Details, NotFound>>;
        
        public class Handler : IRequestHandler<Query, OneOf<MedicalProfileDto.Response.Details, NotFound>>
        {
            private readonly IMedicalProfileQueryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IMedicalProfileQueryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OneOf<MedicalProfileDto.Response.Details, NotFound>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(request.Id, cancellationToken);
                
                return result.Match<OneOf<MedicalProfileDto.Response.Details, NotFound>>(
                    sc => _mapper.Map<MedicalProfile, MedicalProfileDto.Response.Details>(sc),
                    nf => new NotFound());
            }
        }
    }
}
