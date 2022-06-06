using System.Threading;
using System.Threading.Tasks;
using businesslogic.Features.DoctorFeatures;
using MediatR;
using businesslogic.abstraction.Dto;
using Microsoft.AspNetCore.Mvc;

namespace medical_services.api.Controllers
{
    [Route("api/doctors")]
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
        public async Task<ActionResult<DoctorDto.Response.Details>> GetDoctorById(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DoctorDetails.Query(id), cancellationToken);
            return result.Match<ActionResult<DoctorDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto.Response.Details>> CreateDoctor([FromBody]DoctorDto.Request.Create doctor, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DoctorCreate.Command(doctor), cancellationToken);
            return Created(Url.Action(nameof(GetDoctorById), new { id = result.Id }), result);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<DoctorDto.Response.Details>> UpdateDoctor(long id, [FromBody]DoctorDto.Request.Update doctor, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new DoctorUpdate.Command(id, doctor), cancellationToken);

            return result.Match<ActionResult<DoctorDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctor(long id, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new DoctorDelete.Command(id), cancellationToken);

            return result.Match<IActionResult>(
                sc => NoContent(),
                nf => NotFound());
        }
    }
}
