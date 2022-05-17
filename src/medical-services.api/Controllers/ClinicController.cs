using medical_services.api.Controllers.dto.request;
using medical_services.api.Controllers.dto.responce;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api/clinic")]
    public class ClinicController : Controller
    {
        [HttpGet("{id}")]
        public async Task<ClinicResponceDto> GetClinic(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("create")]
        public async Task CreateClinic([FromBody] ClinicRequestDto clinic)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void UpdateClinic(long id, [FromBody] ClinicRequestDto clinic)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteClinic(long id)
        {
            throw new NotImplementedException();
        }
    }
}
