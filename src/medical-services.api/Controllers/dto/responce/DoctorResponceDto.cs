using System.Collections.Generic;

namespace medical_services.api.Controllers.dto.responce
{

    public record DoctorResponceDto(
        long ID,
        string Name,
        IReadOnlyCollection<string> Profile,
        IReadOnlyCollection<string> Clinic);

}
