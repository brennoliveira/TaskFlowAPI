using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Infrastructure.Interfaces
{
    public interface ITaskItemsRepository
    {
        Task<List<TaskItem>> GetUserTasksAsync(Guid userId);
        Task<TaskItem?> GetTaskByIdAsync(Guid userId, Guid id);
        Task AddTaskAsync(TaskItem task);
        Task UpdateTaskAsync(TaskItem task);
        Task DeleteTaskAsync(Guid id);
    }
}
