using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;

namespace businesslogic.Features.DoctorFeatures
{
    public static class ClinicCreate
    {
        public record Command(ClinicDto.Request.Create Clinic) : ICommandRequest<ClinicDto.Response.Details>;

        public class Handler : IRequestHandler<Command, ClinicDto.Response.Details>
        {
            private readonly IClinicCommandRepository _repository;
            private readonly IMapper _mapper;
            
            public Handler(IClinicCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<ClinicDto.Response.Details> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.CreateAsync(request.Clinic, cancellationToken);
                return _mapper.Map<Clinic, ClinicDto.Response.Details>(result);
            }
        }
    }
}
