using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using datalayer.abstraction.Repositories;
using MediatR;
using OneOf.Types;
using OneOf;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;

namespace businesslogic.Features.DoctorFeatures
{
    public static class UpdateDoctorMedicalProfiles
    {
        public record Command(long DoctorId, IReadOnlyList<long> MedicalProfileIds) : ICommandRequest<OneOf<DoctorDto.Response.Details, NotFound>>;

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
                var result = await _repository.UpdateMedicalProfilesAsync(request.DoctorId, request.MedicalProfileIds, cancellationToken);
                return result.Match<OneOf<DoctorDto.Response.Details, NotFound>>(
                     sc => _mapper.Map<Doctor, DoctorDto.Response.Details>(sc),
                     nf => new NotFound());
            }
        }
    }
}
