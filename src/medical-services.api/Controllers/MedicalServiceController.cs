using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using medical_services.api.Controllers.Dto.responce;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api")]
    public class MedicalServiceController : ControllerBase
    {

        [HttpGet("doctors")]
        public async Task<DoctorResponceDto> GetDoctors()
        {
            throw new NotImplementedException();
        }

        [HttpGet("medicalprofiles")]
        public async Task<IReadOnlyCollection<MedicalProfileResponceDto>> GetMedicalProfiles()
        {
            throw new NotImplementedException();
        }


    }
}
