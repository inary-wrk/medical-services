using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using businesslogic.abstraction.ValueObjects;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;

namespace businesslogic.Features.DoctorFeatures
{
    public static class DoctorCreate
    {
        public record Command(DoctorDto.Request.Create Doctor) : ICommandRequest<Id>;

        public class Handler : IRequestHandler<Command, Id>
        {
            private readonly IDoctorCommandRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IDoctorCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<Id> Handle(Command request, CancellationToken cancellationToken)
            {
                var doctor = _mapper.Map<DoctorDto.Request.Create, Doctor>(request.Doctor);
                var result = await _repository.AddAsync(doctor, cancellationToken);
                return result.Id;
            }
        }
    }
}
