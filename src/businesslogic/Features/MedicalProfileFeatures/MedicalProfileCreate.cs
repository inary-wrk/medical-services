using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;

namespace businesslogic.Features.MedicalProfileFeatures
{
    public static class MedicalProfileCreate
    {
        public record Command(MedicalProfileDto.Request.Create MedicalProfile) : ICommandRequest<MedicalProfileDto.Response.Details>;

        public class Handler : IRequestHandler<Command, MedicalProfileDto.Response.Details>
        {
            private readonly IMedicalProfileCommandRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IMedicalProfileCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            
            public async Task<MedicalProfileDto.Response.Details> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.CreateAsync(request.MedicalProfile, cancellationToken);
                return _mapper.Map<MedicalProfile, MedicalProfileDto.Response.Details>(result);
            }
        }
    }
}
