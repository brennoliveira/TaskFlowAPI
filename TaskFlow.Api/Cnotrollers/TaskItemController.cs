using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.DTOs;
using System.Security.Claims;

namespace TaskFlow.Api.Cnotrollersa
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class TaskItemController(ITaskItemsService taskItemsService) : ControllerBase
    {
        private readonly ITaskItemsService _taskItemsService = taskItemsService;

        [HttpGet]
        public async Task<IActionResult> GetUserTasksAsync()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _taskItemsService.GetUserTasksAsync(Guid.Parse(userId));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _taskItemsService.GetTaskByIdAsync(Guid.Parse(userId), id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskItemDTO dto)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            await _taskItemsService.AddTaskAsync(Guid.Parse(userId), dto);
            return Ok(new { Message = "Task created successfully" });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(Guid id, [FromBody] UpdateTaskItemDTO dto)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _taskItemsService.UpdateTaskAsync(Guid.Parse(userId), id, dto);
                return Ok(new { Message = "Task updated successfully" });
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(Guid id)
        {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _taskItemsService.DeleteTaskAsync(Guid.Parse(userId), id);
                return Ok(new { Message = "Task deleted successfully" });
        }
    }
}
