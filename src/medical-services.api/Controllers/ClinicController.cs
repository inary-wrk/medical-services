using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using businesslogic.abstraction.Dto;
using MediatR;
using businesslogic.Features.ClinicFeatures;
using businesslogic.Features.DoctorFeatures;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api/clinic")]
    [ApiVersion("1.0")]
    public class ClinicController : Controller
    {
        private readonly IMediator _mediator;

        public ClinicController(IMediator field)
        {
            _mediator = field;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClinicAsync(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicDetails.Query(id), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateClinicAsync([FromBody]ClinicDto.Request.Create clinic, CancellationToken cancellationToken)
        {
           var result = await _mediator.Send(new ClinicCreate.Command(clinic), cancellationToken);
            return Ok(result);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> UpdateClinicAsync(long id, [FromBody]ClinicDto.Request.Update clinic, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicUpdate.Command(id, clinic), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> DeleteClinicAsync(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new ClinicDelete.Command(id), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(),
                nf => NotFound());
        }
    }
}
