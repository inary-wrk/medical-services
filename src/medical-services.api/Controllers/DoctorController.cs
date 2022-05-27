using System;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.Features.DoctorFeatures;
using MediatR;
using medical_services.api.Controllers.ApiContracts;
using businesslogic.abstraction.Dto;
using Microsoft.AspNetCore.Mvc;
using businesslogic.abstraction.Contracts;

namespace medical_services.api.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DoctorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public DoctorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<DoctorApi.Response.Details> GetDoctorDetails(long id, CancellationToken cancellationToken)
        {
            var query = new DoctorDetails.Query(id);
            var result = await _mediator.Send(query, cancellationToken);
            return _mapper.Map<DoctorDto.Doctor, DoctorApi.Response.Details>(result);
        }

        [HttpPost("create")]
        public async Task<DoctorApi.Response.DoctorId> CreateDoctor([FromBody] DoctorApi.Request.CreateTest doctor, CancellationToken cancellationToken)
        {
            var doctorDto = _mapper.Map<DoctorApi.Request.CreateTest, DoctorDto.Request.Create>(doctor);
            var command = new DoctorCreate.Command(doctorDto);
            var result = await _mediator.Send(command, cancellationToken);
            return new DoctorApi.Response.DoctorId(result);
        }

        [HttpPut("{id}")]
        public async void UpdateDoctor(long id, [FromBody] DoctorDto.Request.Create doctor, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async void DeleteDoctor(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
