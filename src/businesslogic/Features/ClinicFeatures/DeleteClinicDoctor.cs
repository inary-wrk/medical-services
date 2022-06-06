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

namespace businesslogic.Features.ClinicFeatures
{
    public static class DeleteClinicDoctor
    {
        public record Command(long ClinicId, long DoctorId) : ICommandRequest<OneOf<Success, NotFound>>;
        public class Handler : IRequestHandler<Command, OneOf<Success, NotFound>>
        {
            private readonly IClinicCommandRepository _repository;

            public Handler(IClinicCommandRepository repository)
            {
                _repository = repository;
            }

            public async Task<OneOf<Success, NotFound>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _repository.RemoveClinicDoctorAsync(request.ClinicId, request.DoctorId, cancellationToken);
            }
        }
    }
}
