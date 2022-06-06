using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using MediatR;
using System.Threading;
using businesslogic.abstraction.Contracts;
using datalayer.abstraction.Repositories;
using datalayer.abstraction.Entities;
using OneOf.Types;
using OneOf;

namespace businesslogic.Features.DoctorFeatures
{
    public static class DoctorDetails
    {
        public record Query(long Id) : IQueryRequest<OneOf<DoctorDto.Response.Details, NotFound>>;

        public class Handler : IRequestHandler<Query, OneOf<DoctorDto.Response.Details, NotFound>>
        {
            private readonly IDoctorQueryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IDoctorQueryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OneOf<DoctorDto.Response.Details, NotFound>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetAsync(request.Id, cancellationToken);
                return result.Match<OneOf<DoctorDto.Response.Details, NotFound>>(
                    sc => _mapper.Map<Doctor, DoctorDto.Response.Details>(sc),
                    nf => new NotFound());
            }
        }
    }
}
