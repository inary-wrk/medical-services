using System.Threading;
using System.Threading.Tasks;
using businesslogic.Features.DoctorFeatures;
using MediatR;
using businesslogic.abstraction.Dto;
using Microsoft.AspNetCore.Mvc;

namespace medical_services.api.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    [ApiVersion("1.0")]
    public class DoctorController : Controller
    {
        private readonly IMediator _mediator;

        public DoctorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorDetails(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DoctorDetails.Query(id), cancellationToken);
            return result.Match<IActionResult>(
                success => Ok(success),
                notFound => NotFound("Doctor with given id does not exist"));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateDoctor([FromBody]DoctorDto.Request.Create doctor, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DoctorCreate.Command(doctor), cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateDoctor(long id, [FromBody]DoctorDto.Request.Update doctor, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new DoctorUpdate.Command(id, doctor), cancellationToken);

            return result.Match<IActionResult>(
                success => Ok(success),
                notFound => NotFound("Doctor with given id does not exist"));
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteDoctor(long id, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new DoctorDelete.Command(id), cancellationToken);

            return result.Match<IActionResult>(
                success => Ok(),
                notFound => NotFound("Doctor with given id does not exist"));
        }
    }
}
