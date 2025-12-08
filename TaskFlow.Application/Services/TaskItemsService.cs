using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces;
using TaskFlow.Domain.Entities;
using TaskFlow.Infrastructure.Interfaces;

namespace TaskFlow.Application.Services
{
    public class TaskItemsService
            (
            ITaskItemsRepository taskItemRepository,
            IUserRepository userRepository
            )
            : ITaskItemsService
    {
        public readonly ITaskItemsRepository _taskItemRepository = taskItemRepository;
        public readonly IUserRepository _userRepository = userRepository;

        public async Task<List<TaskItem>> GetUserTasksAsync(Guid userId)
        {
            var userExists = await _userRepository.GetUserByIdAsync(userId);
            if (userExists == null)
            {
                throw new Exception("User does not exist.");
            }

            return await _taskItemRepository.GetUserTasksAsync(userId);
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid userId, Guid id)
        {
            var userExists = await _userRepository.GetUserByIdAsync(userId);
            if (userExists == null)
            {
                throw new Exception("User does not exist.");
            }

            var task = await _taskItemRepository.GetTaskByIdAsync(userId, id);
            if (task == null)
            {
                throw new Exception("Task not found.");
            }

            return task;
        }

        public async Task AddTaskAsync(TaskItem taskItem)
        {
            var userExists = await _userRepository.GetUserByIdAsync(taskItem.UserId);
            if (userExists == null)
            {
                throw new Exception("User does not exist.");
            }
            await _taskItemRepository.AddTaskAsync(taskItem);
        }

        public async Task UpdateTaskAsync(TaskItem taskItem)
        {
            var existingTask = await _taskItemRepository.GetTaskByIdAsync(taskItem.UserId, taskItem.Id);
            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }
            await _taskItemRepository.UpdateTaskAsync(taskItem);
        }

        public async Task DeleteTaskAsync(Guid id)
        {
            var existingTask = await _taskItemRepository.GetTaskByIdAsync(Guid.Empty, id);
            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }
            await _taskItemRepository.DeleteTaskAsync(id);
        }
    }
}
