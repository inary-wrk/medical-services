using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.Dto;
using businesslogic.Features.MedicalProfileFeatures;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace medical_services.api.Controllers
{
    [Route("api/{cityCode}/medicalprofiles")]
    [ApiController]
    [ApiVersion("1.0")]
    public class MedicalProfileController : Controller
    {
        private readonly IMediator _mediator;

        public MedicalProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMedicalProfileById(long id, string cityCode, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileDetails.Query(id, cityCode), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(sc),
                nf => NotFound());
        }

        [HttpGet]
        public async Task<IActionResult> GetMedicalProfiles([FromQuery]string? cityCode, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileList.Query(cityCode), cancellationToken);
            return Ok(result);
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateMedicalProfile([FromBody]MedicalProfileDto.Request.Create medicalProfile, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileCreate.Command(medicalProfile), cancellationToken);
            return Created(Url.Action(nameof(GetMedicalProfileById), new { id = result.Id }), result);
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateMedicalProfile(long id, [FromBody]MedicalProfileDto.Request.Update medicalProfile, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new MedicalProfileUpdate.Command(id, medicalProfile), cancellationToken);
            return result.Match<IActionResult>(
                sc => Ok(sc),
                nf => NotFound());
        }
    }
}
