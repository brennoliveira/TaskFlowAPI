using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Events;

namespace TaskFlow.Infrastructure.Messaging.Consumers
{
    public class TaskCreatedConsumer : IConsumer<TaskCreatedEvent>
    {
        public Task Consume(ConsumeContext<TaskCreatedEvent> context)
        {
            Console.WriteLine($"[EVENT RECEIVED] Task: {context.Message.TaskId}");
            return Task.CompletedTask;
        }
    }
}
