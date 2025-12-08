using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Interfaces
{
    public interface ITaskItemsService
    {
        Task<List<TaskItem>> GetUserTasksAsync(Guid userId);
        Task<TaskItem?> GetTaskByIdAsync(Guid userId, Guid id);
        Task AddTaskAsync(TaskItem taskItem);
        Task UpdateTaskAsync(TaskItem taskItem);
        Task DeleteTaskAsync(Guid id);
    }
}
