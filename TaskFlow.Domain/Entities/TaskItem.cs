using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Common;
using TaskFlow.Domain.Enums;

namespace TaskFlow.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public TaskStats Status { get; set; } = TaskStats.Pending;

        // Foreign key to User
        public Guid UserId { get; set; }
        public User? User { get; set; }

        public void Update(
            string title,
            string description,
            DateTime dueDate,
            TaskStats status)
        {
            Title = title;
            Description = description;
            DueDate = dueDate;
            Status = status;
        }
    }
}
