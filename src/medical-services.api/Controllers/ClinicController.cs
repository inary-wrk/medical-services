using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace medical_services.api.Controllers
{
    [ApiController]
    [Route("api/clinic")]
    [ApiVersion("1.0")]
    public class ClinicController : Controller
    {
        [HttpGet("{id}")]
        public async Task GetClinic(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPost("create")]
        public async Task CreateClinic( CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpPut("{id}")]
        public async Task UpdateClinic(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        [HttpDelete("{id}")]
        public async Task DeleteClinic(long id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
