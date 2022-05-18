using System.Collections.Generic;

namespace medical_services.api.Controllers.Dto.responce
{

    public record DoctorResponceDto(
        long Id,
        string Name,
        IReadOnlyCollection<string> Profile,
        IReadOnlyCollection<string> Clinic);

}
