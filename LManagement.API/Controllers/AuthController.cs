using LManagement.API.Models;
using LManagement.Application.DTOs.UserDtos;
using LManagement.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace LManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<User>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<User>>> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();

                return BadRequest(new ApiResponse<User>
                {
                    Success = false,
                    Message = "User data is invalid.",
                    Data = null,
                    Errors = errorMessages
                });
            }
            var user = new User
            {
                Username = userCreateDto.Username,
                Email = userCreateDto.Email,
                FirstName = userCreateDto.FirstName,
                LastName = userCreateDto.LastName,
                Role = userCreateDto.Role
            };

            var hashedPassword = new PasswordHasher<User>().HashPassword(user, userCreateDto.Password);
            // user.PasswordHash = hashedPassword;

            return Ok(new ApiResponse<User>
            {
                Success = true,
                Message = "User created successfully.",
                Data = user,
            });
        }
    }
}
