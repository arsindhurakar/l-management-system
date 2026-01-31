using LManagement.API.Extensions;
using LManagement.Application.DTOs.LeadDtos;
using LManagement.Application.Interfaces.Services;
using LManagement.Application.Models.Pagination;
using LManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using LManagement.API.Models.Responses;
using LManagement.Infrastructure.Providers;
using LManagement.Application.Interfaces;
using LManagement.Application.Dtos;

namespace LManagement.API.Controllers
{
    [ApiController]
    [Route("api/leads")]
    public class LeadController : ControllerBase
    {
        private readonly ILeadService _leadService;
        private readonly ILogger<LeadController> _logger;
        private readonly ISortFieldsProvider _sortFieldsProvider;

        public LeadController(ILeadService leadService, ILogger<LeadController> logger, ISortFieldsProvider sortFieldsProvider)
        {
            _leadService = leadService;
            _logger = logger;
            _sortFieldsProvider = sortFieldsProvider;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaginatedApiResponse<IEnumerable<Lead>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<PaginatedApiResponse<IEnumerable<Lead>>>> GetLeads(
            [FromQuery] PageRequestDto pageRequestDto)
        {
            var validFields = _sortFieldsProvider.GetSortFields<Lead>();
            var pageRequest = new PageRequest(validFields)
            {
                Page = pageRequestDto.Page,
                PageSize = pageRequestDto.PageSize,
                SortBy = pageRequestDto.SortBy,
                SortOrder = pageRequestDto.SortOrder
            };
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

                return NotFound(ApiResponse<Lead>.FailResponse("No lead found."));
            }

            return Ok(ApiResponse<Lead>.SuccessResponse(lead, "Lead fetched successfully"));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponse<Lead>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse<Lead>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ApiResponse<Lead>>> CreateLead([FromBody] LeadCreateDto leadCreateDto)
        {
            var createdLead = await _leadService.CreateLeadAsync(leadCreateDto);

            return CreatedAtAction(nameof(GetLeadById), new { id = createdLead.Id }, ApiResponse<Lead>
                .SuccessResponse(createdLead, "Lead created successfully."));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiResponse<Lead>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse<Lead>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ApiResponse<Lead>>> UpdateLead(int id, [FromBody] LeadUpdateDto leadUpdateDto)
        {
            var lead = await _leadService.UpdateLeadAsync(id, leadUpdateDto);

            if (lead == null)
            {
                _logger.LogInformation("Lead with ID {LeadId} not found for update.", id);

                return NotFound(ApiResponse<Lead>.FailResponse("Lead not found."));
            }
          
            return Ok(ApiResponse<Lead>.SuccessResponse(lead, "Lead updated successfully"));

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

                return NotFound(ApiResponse<Lead>.FailResponse("Lead not found."));
            }

            return Ok(ApiResponse<bool>.SuccessResponse(true, "Lead deleted successfully"));
        }
    }
}
