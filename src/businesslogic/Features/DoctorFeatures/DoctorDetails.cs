using System.Threading.Tasks;
using businesslogic.abstraction.ValueObjects;
using businesslogic.abstraction.Dto;
using MediatR;
using System.Threading;
using businesslogic.abstraction.Contracts;
using datalayer.abstraction.Repositories;
using datalayer.abstraction.Entities;

namespace businesslogic.Features.DoctorFeatures
{
    public static class DoctorDetails
    {
        public record Query(Id DoctorId) : IQueryRequest<DoctorDto.Doctor>;

        public class QueryHandler : IRequestHandler<Query, DoctorDto.Doctor>
        {
            private readonly IDoctorQueryRepository _repository;
            private readonly IMapper _mapper;

            public QueryHandler(IDoctorQueryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<DoctorDto.Doctor> Handle(Query request, CancellationToken cancellationToken)
            {
              var result = await _repository.GetByIdAsync(request.DoctorId, cancellationToken);
                return _mapper.Map<Doctor, DoctorDto.Doctor>(result);
            }
        }
    }
}
