using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using MediatR;
using medical_services.api.Controllers.Dto.responce;
using medical_services.api.Queries;

namespace medical_services.api.Handlers
{
    public class GetDoctorQueryHandler : IRequestHandler<GetDoctorQuery, DoctorResponceDto>
    {
        Task<DoctorResponceDto> IRequestHandler<GetDoctorQuery, DoctorResponceDto>.Handle(GetDoctorQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
