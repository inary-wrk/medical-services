using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using businesslogic.abstraction.Dto;
using MediatR;
using businesslogic.Features.ClinicFeatures;
using businesslogic.Features.DoctorFeatures;
using System.Collections.Generic;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api/clinics")]
    [ApiVersion("1.0")]
    public class ClinicController : Controller
    {
        private readonly IMediator _mediator;

        public ClinicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{clinicId}")]
        public async Task<ActionResult<ClinicDto.Response.Details>> GetClinicById(long clinicId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicDetails.Query(clinicId), cancellationToken);
            return result.Match<ActionResult<ClinicDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpGet("available-cities")]
        public async Task<ActionResult<IReadOnlyList<ClinicDto.Response.CityCode>>> GetAvailableCities(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AvailableCities.Query(), cancellationToken);
            return Ok(result);
        }

        // TODO: Address validation via yandex api?? slug generation
        [HttpPost]
        public async Task<ActionResult<ClinicDto.Response.Details>> CreateClinic([FromBody] ClinicDto.Request.Create clinic, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicCreate.Command(clinic), cancellationToken);
            return Created(Url.Action(nameof(GetClinicById), new { id = result.Id }), result);
        }

        [HttpPatch("{clinicId}")]
        public async Task<ActionResult<ClinicDto.Response.Details>> UpdateClinic(long clinicId,
                                                                                 [FromBody] ClinicDto.Request.Update clinic,
                                                                                 CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicUpdate.Command(clinicId, clinic), cancellationToken);
            return result.Match<ActionResult<ClinicDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpDelete("{clinicId}")]
        public async Task<ActionResult> DeleteClinic(long clinicId, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicDelete.Command(clinicId), cancellationToken);
            return result.Match<ActionResult>(
                sc => NoContent(),
                nf => NotFound());
        }

        [HttpPut("{clinicId}/doctors/{doctorId}")]
        public async Task<ActionResult<ClinicDto.Response.Details>> UpdateClinicDoctor(long clinicId,
                                                                                       long doctorId,
                                                                                       IReadOnlyList<long> medicalProfileIds,
                                                                                       CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateClinicDoctor.Command(clinicId, doctorId, medicalProfileIds), cancellationToken);
            return result.Match<ActionResult<ClinicDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpDelete("{clinicId}/doctors/{doctorId}")]
        public async Task<ActionResult> DeleteClinicDoctor(long clinicId,
                                                           long doctorId,
                                                           CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteClinicDoctor.Command(clinicId, doctorId), cancellationToken);
            return result.Match<ActionResult>(
                sc => NoContent(),
                nf => NotFound());
        }
    }
}
