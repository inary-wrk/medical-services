using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using businesslogic.Features.MedicalProfileFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace medical_services.api.Controllers
{
    [Route("api/medicalprofiles")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MedicalProfileController : Controller
    {
        private readonly IMediator _mediator;

        public MedicalProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{cityCode}/{id}")]
        public async Task<ActionResult<MedicalProfileDto.Response.GetByIdDetails>> GetMedicalProfileById(long id, string cityCode, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileDetails.Query(id, cityCode), cancellationToken);
            return result.Match<ActionResult<MedicalProfileDto.Response.GetByIdDetails>>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpGet]
        public async Task<ActionResult<MedicalProfileDto.Response.Details>> GetMedicalProfiles(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileList.Query(), cancellationToken);
            return Ok(result);
        }

        [HttpGet("{cityCode}")]
        public async Task<ActionResult<MedicalProfileDto.Response.Details>> GetMedicalProfiles(string cityCode, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileList.Query(cityCode), cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<MedicalProfileDto.Response.Details>> CreateMedicalProfile([FromBody] MedicalProfileDto.Request.Create medicalProfile, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileCreate.Command(medicalProfile), cancellationToken);
            return Ok(result);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<MedicalProfileDto.Response.Details>> UpdateMedicalProfile(long id, [FromBody] MedicalProfileDto.Request.Update medicalProfile, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileUpdate.Command(id, medicalProfile), cancellationToken);
            return result.Match<ActionResult<MedicalProfileDto.Response.Details>>(
                sc => Ok(sc),
                nf => NotFound());
        }
    }
}
