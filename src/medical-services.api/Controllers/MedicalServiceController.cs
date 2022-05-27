using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api")]
    [ApiVersion("1.0")]
    public class MedicalServiceController : Controller
    {
        [HttpGet("doctors")]
        public async Task GetDoctors(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpGet("medicalprofiles")]
        public async Task GetMedicalProfiles(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
