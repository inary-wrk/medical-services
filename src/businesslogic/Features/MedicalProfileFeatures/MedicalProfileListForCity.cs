using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Contracts;
using businesslogic.abstraction.Dto;
using datalayer.abstraction.Entities;
using datalayer.abstraction.Repositories;
using MediatR;

namespace businesslogic.Features.MedicalProfileFeatures
{
    public static class MedicalProfileList
    {
        public record Query(string? CityCode) : IQueryRequest<IReadOnlyList<MedicalProfileDto.Response.Details>>;

        public class Handler : IRequestHandler<Query, IReadOnlyList<MedicalProfileDto.Response.Details>>
        {
            private readonly IMedicalProfileQueryRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IMedicalProfileQueryRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IReadOnlyList<MedicalProfileDto.Response.Details>> Handle(Query request, CancellationToken cancellationToken)
            {
                if (request.CityCode is null)
                {
                    var result = await _repository.GetListAsync(cancellationToken);
                    return _mapper.Map<IReadOnlyList<MedicalProfile>, IReadOnlyList<MedicalProfileDto.Response.Details>>(result);
                }
                else
                {
                    var result = await _repository.GetListAsync(request.CityCode, cancellationToken);
                    return _mapper.Map<IReadOnlyList<(MedicalProfile, int doctorsCount)>, IReadOnlyList<MedicalProfileDto.Response.Details>>(result);
                }
            }
        }
    }
}
