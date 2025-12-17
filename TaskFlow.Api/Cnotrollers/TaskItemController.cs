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
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _taskItemsService.GetUserTasksAsync(Guid.Parse(userId));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid id)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var result = await _taskItemsService.GetTaskByIdAsync(Guid.Parse(userId), id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] CreateTaskItemDTO dto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                await _taskItemsService.AddTaskAsync(Guid.Parse(userId), dto);
                return Ok(new { Message = "Task created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskAsync(Guid id, [FromBody] UpdateTaskItemDTO dto)
        {
            try
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                await _taskItemsService.UpdateTaskAsync(Guid.Parse(userId), id, dto);
                return Ok(new { Message = "Task updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAsync(Guid id)
        {
            try
            {
                await _taskItemsService.DeleteTaskAsync(id);
                return Ok(new { Message = "Task deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
