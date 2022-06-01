using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using businesslogic.Features.MedicalProfileFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace medical_services.api.Controllers
{
    [Route("api/medicalprofile")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MedicalProfileConntroller : Controller
    {
        private readonly IMediator _mediator;
        public MedicalProfileConntroller(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{city}")]
        // TODO: change city to (city, region, country) ??, city not found
        public async Task<IActionResult> GetMedicalProfilesAsync(string city, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileDetails.Query(city), cancellationToken);

            return Ok(result);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateMedicalProfileAsync([FromBody]MedicalProfileDto.Request.Create medicalProfile, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileCreate.Command(medicalProfile), cancellationToken);
            return Ok(result);
        }

        [HttpPut]
        [Route("{id}/update")]
        public async Task<IActionResult> UpdateMedicalProfileAsync(long id, [FromBody]MedicalProfileDto.Request.Update medicalProfile, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileUpdate.Command(id, medicalProfile), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpDelete]
        [Route("{id}/delete")]
        public async Task<IActionResult> DeleteMedicalProfileAsync(long id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileDelete.Command(id), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(),
                nf => NotFound());
        }
    }
}
