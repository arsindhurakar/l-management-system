using LManagement.API.Models;
using LManagement.API.Extensions;
using LManagement.Application.DTOs.LeadDtos;
using LManagement.Application.Interfaces.Services;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace LManagement.API.Controllers
{
    [ApiController]
    [Route("api/leads")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;
        private readonly ILogger<LeadController> _logger;

        public LeadController(ILeadService leadService, ILogger<LeadController> logger)
        {
            _leadService = leadService;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ApiResponse<IEnumerable<Lead>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<ApiResponse<IEnumerable<Lead>>>> GetLeads(
            [FromQuery] PageRequest pageRequest)
        {
            var pagedResult = await _leadService.GetAllLeadsAsync(pageRequest);
            bool hasLeads = pagedResult.Items.Any();
            string message = hasLeads ? "Leads fetched successfully." : "No leads found.";

            if (!hasLeads)
            {
                _logger.LogInformation(message);
            }

            return Ok(pagedResult.ToPaginationResponse(message));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Lead>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<Lead>>> GetLeadById(int id)
        {
            var lead = await _leadService.GetLeadByIdAsync(id);

            if (lead == null)
            {
                _logger.LogInformation("Lead with ID {LeadId} not found.", id);

                return NotFound(new ApiResponse<Lead>
                {
                    Success = false,
                    Message = "No lead found.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<Lead>
            {
                Success = true,
                Message = "Lead fetched successfully.",
                Data = lead
            });
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Lead>), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Lead>>> CreateLead([FromBody] LeadCreateDto leadCreateDto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();

                _logger.LogWarning("CreateLead validation failed. Errors: {Errors}", errorMessages);

                return BadRequest(new ApiResponse<Lead>
                {
                    Success = false,
                    Message = "Lead data is invalid.",
                    Data = null,
                    Errors = errorMessages
                });
            }

            var createdLead = await _leadService.CreateLeadAsync(leadCreateDto);

            return CreatedAtAction(nameof(GetLeadById), new { id = createdLead.Id }, new ApiResponse<Lead>
            {
                Success = true,
                Message = "Lead created successfully.",
                Data = createdLead
            });
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Lead>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<Lead>>> UpdateLead(int id, [FromBody] LeadUpdateDto leadUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                var errorMessages = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();

                _logger.LogWarning("UpdateLead validation failed. Errors: {Errors}", errorMessages);

                return BadRequest(new ApiResponse<Lead>
                {
                    Success = false,
                    Message = "Lead data is invalid.",
                    Data = null,
                    Errors = errorMessages
                });
            }

            var lead = await _leadService.UpdateLeadAsync(id, leadUpdateDto);

            if (lead == null)
            {
                _logger.LogInformation("Lead with ID {LeadId} not found for update.", id);

                return NotFound(new ApiResponse<Lead>
                {
                    Success = false,
                    Message = "Lead not found.",
                    Data = null
                });
            }

            return Ok(new ApiResponse<Lead>
            {
                Success = true,
                Message = "Lead updated successfully.",
                Data = lead
            });
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiResponse<bool>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<bool>>> DeleteLead(int id)
        {
            var isDeleted = await _leadService.DeleteLeadAsync(id);

            if (!isDeleted)
            {
                _logger.LogInformation("Lead with ID {LeadId} not found for deletion.", id);

                return NotFound(new ApiResponse<bool>
                {
                    Success = false,
                    Message = "Lead not found.",
                    Data = false
                });
            }

            return Ok(new ApiResponse<bool>
            {
                Success = true,
                Message = "Lead deleted successfully.",
                Data = true
            });
        }
    }
}
