using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using datalayer.abstraction.Repositories;
using MediatR;
using OneOf;
using OneOf.Types;

namespace businesslogic.Features.DoctorFeatures
{
    public static class ClinicDelete
    {
        public record Command(long Id) : ICommandRequest<OneOf<Success, NotFound>>;

        public class Handler : IRequestHandler<Command, OneOf<Success, NotFound>>
        {
            private readonly IClinicCommandRepository _repository;

            public Handler(IClinicCommandRepository repository)
            {
                _repository = repository;
            }

            public async Task<OneOf<Success, NotFound>> Handle(Command request, CancellationToken cancellationToken)
            {
                return await _repository.DeleteAsync(request.Id, cancellationToken);
            }
        }
    }
}
