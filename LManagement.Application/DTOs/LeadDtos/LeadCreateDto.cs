using System.ComponentModel.DataAnnotations;

namespace LManagement.Application.DTOs.LeadDtos
{
    public class LeadCreateDto
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }


        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^(98|97|96)[0-9]{8}$",
            ErrorMessage = "Phone Number is invalid.")]

        public string? Company { get; set; }

        [Required(ErrorMessage = "Source is required.")]
        public string Source { get; set; } = string.Empty;
    }
}
