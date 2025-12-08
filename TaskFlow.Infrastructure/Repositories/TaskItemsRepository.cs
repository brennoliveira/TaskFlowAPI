using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Infrastructure.Data;
using TaskFlow.Infrastructure.Interfaces;
using TaskFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskFlow.Infrastructure.Repositories
{
    public class TaskItemsRepository(AppDbContext context) : ITaskItemsRepository
    {
        private readonly AppDbContext _context = context;

        public async Task<List<TaskItem>> GetUserTasksAsync(Guid userId)
        {
            return await _context.TaskItems.Where(task => task.UserId == userId).ToListAsync();
        }
        public async Task<TaskItem?> GetTaskByIdAsync(Guid userId, Guid id)
        {
            return await _context.TaskItems
                .FirstOrDefaultAsync(task => task.UserId == userId && task.Id == id);
        }
        public async Task AddTaskAsync(TaskItem taskItem)
        {
            await _context.TaskItems.AddAsync(taskItem);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateTaskAsync(TaskItem taskItem)
        {
            _context.TaskItems.Update(taskItem);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteTaskAsync(Guid id)
        {
            var taskItem = await _context.TaskItems.FindAsync(id);
            if (taskItem != null)
            {
                _context.TaskItems.Remove(taskItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
