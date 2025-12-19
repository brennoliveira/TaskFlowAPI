using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.DTOs;
using TaskFlow.Application.Interfaces;
using TaskFlow.CrossCutting.Exceptions;
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

        public async Task<List<TaskItemDTO>> GetUserTasksAsync(Guid userId)
        {
            var userExists = await _userRepository.GetUserByIdAsync(userId);
            if (userExists == null)
            {
                throw new NotFoundException("User does not exist.");
            }

            var tasks = await _taskItemRepository.GetUserTasksAsync(userId);

            return tasks.Select(task => new TaskItemDTO
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt,
                DueDate = task.DueDate,
                Status = task.Status
            }).ToList();
        }

        public async Task<TaskItem?> GetTaskByIdAsync(Guid userId, Guid id)
        {
            var userExists = await _userRepository.GetUserByIdAsync(userId);
            if (userExists == null)
            {
                throw new NotFoundException("User does not exist.");
            }

            var task = await _taskItemRepository.GetTaskByIdAsync(userId, id);
            if (task == null)
            {
                throw new NotFoundException("Task not found.");
            }

            return task;
        }

        public async Task AddTaskAsync(Guid userId, CreateTaskItemDTO dto)
        {
            var task = new TaskItem
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Title = dto.Title,
                Description = dto.Description ?? string.Empty,
                CreatedAt = DateTime.UtcNow,
                DueDate = dto.DueDate
            };

            var userExists = await _userRepository.GetUserByIdAsync(task.UserId);
            if (userExists == null)
            {
                throw new NotFoundException("User does not exist.");
            }
            await _taskItemRepository.AddTaskAsync(task);
        }

        public async Task UpdateTaskAsync(Guid userId, Guid taskId, UpdateTaskItemDTO dto)
        {
            var existingTask = await _taskItemRepository.GetTaskByIdAsync(userId, taskId);
            if (existingTask == null)
            {
                throw new NotFoundException("Task not found.");
            }

            existingTask.Update(
                dto.Title ?? existingTask.Title,
                dto.Description ?? existingTask.Description,
                dto.DueDate ?? existingTask.DueDate,
                dto.Status ?? existingTask.Status
            );

            await _taskItemRepository.UpdateTaskAsync();
        }

        public async Task DeleteTaskAsync(Guid userId, Guid id)
        {
            var existingTask = await _taskItemRepository.GetTaskByIdAsync(userId, id);
            if (existingTask == null)
            {
                throw new NotFoundException("Task not found.");
            }
            await _taskItemRepository.DeleteTaskAsync(id);
        }
    }
}
