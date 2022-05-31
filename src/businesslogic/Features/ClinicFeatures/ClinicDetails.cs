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
    public static class ClinicDetails
    {
        public record Query(long Id) : IQueryRequest<OneOf<ClinicDto.Response.Details, NotFound>>;

        public class Handler : IRequestHandler<Query, OneOf<ClinicDto.Response.Details, NotFound>>
        {
            private readonly IClinicQueryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IClinicQueryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<OneOf<ClinicDto.Response.Details, NotFound>> Handle(Query request, CancellationToken cancellationToken)
            {
                var result = await _repository.GetByIdAsync(request.Id, cancellationToken);

                return result.Match<OneOf<ClinicDto.Response.Details, NotFound>>(
                    sc => _mapper.Map<Clinic, ClinicDto.Response.Details>(sc),
                    nf => new NotFound());
            }
        }

    }
}
