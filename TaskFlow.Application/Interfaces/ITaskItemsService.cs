using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface ITaskItemsService
    {
        Task<List<TaskItemDTO>> GetUserTasksAsync(Guid userId);
        Task<TaskItem?> GetTaskByIdAsync(Guid userId, Guid id);
        Task AddTaskAsync(Guid userId, CreateTaskItemDTO taskItem);
        Task UpdateTaskAsync(Guid userId, Guid taskId, UpdateTaskItemDTO dto);
        Task DeleteTaskAsync(Guid id);
    }
}
