using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace medical_services.api.Controllers.Dto.request
{
    public record DoctorRequestDto
    {
        [BindRequired]
        public string Name { get; init; }
        [BindRequired]
        public List<string> MedicalProfile { get; init; }
        public List<string> Clinic { get; init; }
    }
}
