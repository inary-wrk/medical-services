using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using medical_services.api.Controllers.dto.request;
using medical_services.api.Controllers.dto.responce;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace medical_services.api.Controllers
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<DoctorResponceDto> GetDoctor(long id)
        {
            throw new NotImplementedException();
        }

        [HttpPost("create")]
        public async Task CreateDoctor([FromBody] DoctorRequestDto doctor)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public void UpdateDoctor(long id, [FromBody] DoctorRequestDto doctor)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public void DeleteDoctor(long id)
        {
            throw new NotImplementedException();
        }
    }
}
