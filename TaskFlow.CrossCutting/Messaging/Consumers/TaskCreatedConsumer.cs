using MassTransit;
using TaskFlow.CrossCutting.Messaging.Events;

namespace TaskFlow.CrossCutting.Messaging.Consumers;

public class TaskCreatedConsumer : IConsumer<TaskCreatedEvent>
{
    public Task Consume(ConsumeContext<TaskCreatedEvent> context)
    {
        Console.WriteLine($"[EVENT RECEIVED] Task: {context.Message.TaskId}");
        return Task.CompletedTask;
    }
}
