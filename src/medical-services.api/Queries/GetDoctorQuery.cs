using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using MediatR;
using medical_services.api.Controllers.Dto.responce;

namespace medical_services.api.Queries
{
    public class GetDoctorQuery : IRequest<DoctorResponceDto>
    {
        public long DoctorId { get; set; }

        public GetDoctorQuery(long doctorId)
        {
            DoctorId = doctorId;
        }
    }
}
