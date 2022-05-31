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
    public static class ClinicUpdate
    {
        public record Command(long Id, ClinicDto.Request.Update Clinic) : ICommandRequest<OneOf<ClinicDto.Response.Details, NotFound>>;

        public class Handler : IRequestHandler<Command, OneOf<ClinicDto.Response.Details, NotFound>>
        {
            private readonly IClinicCommandRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IClinicCommandRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OneOf<ClinicDto.Response.Details, NotFound>> Handle(Command request, CancellationToken cancellationToken)
            {
                var dbClinic = _mapper.Map<ClinicDto.Request.Update, Clinic>(request.Clinic);
                var result = await _repository.UpdateAsync(request.Id, dbClinic);
                
                return result.Match<OneOf<ClinicDto.Response.Details, NotFound>>(
                     sc => _mapper.Map<Clinic, ClinicDto.Response.Details>(sc),
                     nf => new NotFound());
            }
        }
    }
}
