using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace medical_services.api.Controllers.Dto.request
{
    public record DoctorRequestDto(
        string Name,
        List<string> MedicalProfile,
        List<string> Clinic);
}
