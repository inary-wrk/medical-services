using System.Threading;
using System.Threading.Tasks;
using businesslogic.Features.DoctorFeatures;
using MediatR;
using businesslogic.abstraction.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        [HttpGet("{doctorId}")]
        public async Task<ActionResult<DoctorDto.Response.Details>> GetDoctorById(long doctorId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DoctorDetails.Query(doctorId), cancellationToken);
            return result.Match<ActionResult<DoctorDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpPost]
        public async Task<ActionResult<DoctorDto.Response.Details>> CreateDoctor([FromBody]DoctorDto.Request.Create doctor, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DoctorCreate.Command(doctor), cancellationToken);
            return Created(Url.Action(nameof(GetDoctorById), new { doctorId = result.Id }), result);
        }

        [HttpPatch("{doctorId}")]
        public async Task<ActionResult<DoctorDto.Response.Details>> UpdateDoctor(long doctorId,
                                                                                 [FromBody] DoctorDto.Request.Update doctor,
                                                                                 CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new DoctorUpdate.Command(doctorId, doctor), cancellationToken);

            return result.Match<ActionResult<DoctorDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpPut("{doctorId}/medicalprofiles")]
        public async Task<ActionResult<DoctorDto.Response.Details>> UpdateDoctorMedicalProfiles(long doctorId,
                                                                                                [FromBody] IReadOnlyList<long> medicalProfiles,
                                                                                                CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateDoctorMedicalProfiles.Command(doctorId, medicalProfiles), cancellationToken);
            return result.Match<ActionResult<DoctorDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpDelete("{doctorId}")]
        public async Task<IActionResult> DeleteDoctor(long doctorId, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new DoctorDelete.Command(doctorId), cancellationToken);

            return result.Match<IActionResult>(
                sc => NoContent(),
                nf => NotFound());
        }
    }
}
