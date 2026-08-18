using LManagement.API.Extensions;
using LManagement.API.Models;
using LManagement.Application.Interfaces.Services;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiPagedResponse<IEnumerable<User>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiPagedResponse<IEnumerable<User>>>> GetUsers(
            [FromQuery] PageRequest pageRequest
        )
        {
            var pagedResult = await _userService.GetAllUsersAsync(pageRequest);
            bool hasUsers = pagedResult.Items.Any();
            string message = hasUsers ? "Users fetched successfully." : "No users found.";

            if (!hasUsers)
            {
                _logger.LogInformation(message);
            }

            return Ok(pagedResult.ToPaginationResponse(message));
        }
    }
}
