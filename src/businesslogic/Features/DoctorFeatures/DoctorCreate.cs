using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;

namespace businesslogic.Features.DoctorFeatures
{
    public static class DoctorCreate
    {
        public record Command(DoctorDto.Request.Create Doctor) : ICommandRequest<DoctorDto.Response.Details>;

        public class Handler : IRequestHandler<Command, DoctorDto.Response.Details>
        {
            private readonly IDoctorCommandRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IDoctorCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DoctorDto.Response.Details> Handle(Command request, CancellationToken cancellationToken)
            {
                var result = await _repository.CreateAsync(request.Doctor, cancellationToken);
                return _mapper.Map<Doctor, DoctorDto.Response.Details>(result);
            }
        }
    }
}
