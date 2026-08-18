using System.ComponentModel.DataAnnotations;
using LManagement.Domain.Enums;

namespace LManagement.Application.DTOs.UserDtos;

public class UserCreateDto
{
    [Required(ErrorMessage = "Username is required.")]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
    [MaxLength(20, ErrorMessage = "Username cannot exceed 20 characters.")]
    public string Username { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required.")]
    [RegularExpression(@"^(?=.*[A-Z])(?=.*[0-9])(?=.*[\W_]).{6,}$",
        ErrorMessage = "Password must be at least 6 characters long and include one uppercase letter, one digit, and one special character.")]
    public string Password { get; set; } = string.Empty;

    [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
        ErrorMessage = "Enter a valid email address.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone Number is required.")]
    [RegularExpression(@"^(98|97|96)[0-9]{8}$",
        ErrorMessage = "Phone Number is invalid.")]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required(ErrorMessage = "User Role is required.")]
    public UserRole Role { get; set; }
}
