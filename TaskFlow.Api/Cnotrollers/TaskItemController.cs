using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Api.Cnotrollers
{
    [ApiController]
    [Route("/api/[controller]")]
    [Authorize]
    public class TaskItemController(ITaskItemsService taskItemsService) : ControllerBase
    {
        private readonly ITaskItemsService _taskItemsService = taskItemsService;

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetUserTasksAsync(Guid userId)
        {
            try
            {
                var result = await _taskItemsService.GetUserTasksAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpGet("{id}/user/{userId}")]
        public async Task<IActionResult> GetTaskByIdAsync(Guid userId, Guid id)
        {
            try
            {
                var result = await _taskItemsService.GetTaskByIdAsync(userId, id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateTaskAsync([FromBody] TaskItem taskItem)
        {
            try
            {
                await _taskItemsService.AddTaskAsync(taskItem);
                return Ok(new { Message = "Task created successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTaskAsync([FromBody] TaskItem taskItem)
        {
            try
            {
                await _taskItemsService.UpdateTaskAsync(taskItem);
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
