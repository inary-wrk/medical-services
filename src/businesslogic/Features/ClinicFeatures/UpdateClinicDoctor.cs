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
using datalayer.abstraction.Entities;

namespace businesslogic.Features.ClinicFeatures
{
    public static class UpdateClinicDoctor
    {
        public record Command(long ClinicId, long DoctorId, IReadOnlyList<long> MedicalProfileIds) : ICommandRequest<OneOf<ClinicDto.Response.Details, NotFound>>;

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
                var result = await _repository.UpdateClinicDoctorAsync(request.ClinicId,
                                                                        request.DoctorId,
                                                                        request.MedicalProfileIds,
                                                                        cancellationToken);
                return result.Match<OneOf<ClinicDto.Response.Details, NotFound>>(
                     sc => _mapper.Map<Clinic, ClinicDto.Response.Details>(sc),
                     nf => new NotFound());
            }
        }
    }
}
