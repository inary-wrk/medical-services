using medical_services.api.Controllers.Dto.request;
using medical_services.api.Controllers.Dto.responce;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api/clinic")]
    public class ClinicController : Controller
    {
        [HttpGet("{id}")]
        internal async Task<ClinicResponceDto> GetClinic(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("create")]
        public async Task CreateClinic([FromBody] ClinicRequestDto clinic, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void UpdateClinic(long id, [FromBody] ClinicRequestDto clinic, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteClinic(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
