using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;
using OneOf;
using OneOf.Types;

namespace businesslogic.Features.MedicalProfileFeatures
{
    public static class MedicalProfileUpdate
    {
        public record Command(long Id, MedicalProfileDto.Request.Update MedicalProfile) : ICommandRequest<OneOf<MedicalProfileDto.Response.Details, NotFound>>;

        public class Handler : IRequestHandler<Command, OneOf<MedicalProfileDto.Response.Details, NotFound>>
        {
            private readonly IMedicalProfileCommandRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IMedicalProfileCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OneOf<MedicalProfileDto.Response.Details, NotFound>> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.UpdateAsync(request.Id, request.MedicalProfile, cancellationToken);
                return result.Match<OneOf<MedicalProfileDto.Response.Details, NotFound>>(
                     sc => _mapper.Map<MedicalProfile, MedicalProfileDto.Response.Details>(sc),
                     nf => new NotFound());
            }
        }
    }
}
