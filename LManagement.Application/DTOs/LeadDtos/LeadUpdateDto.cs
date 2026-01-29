using System.ComponentModel.DataAnnotations;

namespace LManagement.Application.DTOs.LeadDtos
{
    public class LeadUpdateDto
    {
        [Required(ErrorMessage = "First Name is required.")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last Name is required.")]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Phone Number is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone Number must contain only 10 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Company { get; set; }
    }
}
