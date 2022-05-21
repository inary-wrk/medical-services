using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using medical_services.api.Controllers.Dto.request;
using medical_services.api.Controllers.Dto.responce;
using medical_services.api.Queries;
using Microsoft.AspNetCore.Mvc;


namespace medical_services.api.Controllers
{


    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<DoctorResponceDto> GetDoctor(long id, CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetDoctorQuery(id), cancellationToken);
        }

        [HttpPost("create")]
        public async Task CreateDoctor([FromBody] DoctorRequestDto doctor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void UpdateDoctor(long id, [FromBody] DoctorRequestDto doctor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteDoctor(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
