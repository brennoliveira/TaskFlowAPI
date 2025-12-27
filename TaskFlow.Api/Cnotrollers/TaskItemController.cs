using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.DTOs;
using System.Security.Claims;
using TaskFlow.CrossCutting.Responses;
using Microsoft.AspNetCore.Http;
using MassTransit;

namespace TaskFlow.Api.Cnotrollers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class TaskItemController(ITaskItemsService taskItemsService) : ControllerBase
    {
        private readonly ITaskItemsService _taskItemsService = taskItemsService;

        [HttpGet]
        [ProducesResponseType(typeof(ApiSuccessResponse<List<TaskItemDTO>>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetUserTasksAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _taskItemsService.GetUserTasksAsync(Guid.Parse(userId));
            return Ok(new ApiSuccessResponse<List<TaskItemDTO>>(result));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse<TaskItemDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _taskItemsService.GetTaskByIdAsync(Guid.Parse(userId), id);
            return Ok(new ApiSuccessResponse<TaskItemDTO>(result));
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiSuccessResponse), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskItemDTO dto, IBus bus)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _taskItemsService.AddTaskAsync(Guid.Parse(userId), dto);
            return Created("", new ApiSuccessResponse("Task created successfully" ));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateTaskAsync(Guid id, [FromBody] UpdateTaskItemDTO dto)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _taskItemsService.UpdateTaskAsync(Guid.Parse(userId), id, dto);
                return Ok(new ApiSuccessResponse("Task updated successfully"));
        }
        
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ApiSuccessResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteTaskAsync(Guid id)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _taskItemsService.DeleteTaskAsync(Guid.Parse(userId), id);
                return Ok(new ApiSuccessResponse("Task deleted successfully"));
        }
    }
}
