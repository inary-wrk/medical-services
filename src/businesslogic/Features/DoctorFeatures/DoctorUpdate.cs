using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;
using OneOf;
using OneOf.Types;

namespace businesslogic.Features.DoctorFeatures
{
    public static class DoctorUpdate
    {
        public record Command(long Id, DoctorDto.Request.Update Doctor) : ICommandRequest<OneOf<DoctorDto.Response.Details, NotFound>>;

        public class Handler : IRequestHandler<Command, OneOf<DoctorDto.Response.Details, NotFound>>
        {
            private readonly IDoctorCommandRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IDoctorCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OneOf<DoctorDto.Response.Details, NotFound>> Handle(Command request, CancellationToken cancellationToken)
            {
                var dbDoctor = _mapper.Map<DoctorDto.Request.Update, Doctor>(request.Doctor);
                var result = await _repository.UpdateAsync(request.Id, dbDoctor);
                
                return result.Match<OneOf<DoctorDto.Response.Details, NotFound>>(
                     sc => _mapper.Map<Doctor, DoctorDto.Response.Details>(sc),
                     nf => new NotFound());
            }
        }
    }
}
