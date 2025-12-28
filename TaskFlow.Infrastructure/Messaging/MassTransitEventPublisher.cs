using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Application.Interfaces.Messaging;

namespace TaskFlow.Infrastructure.Messaging
{
    public class MassTransitEventPublisher(IPublishEndpoint publishEndpoint) : IMessageBus
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;
        public async Task PublishAsync<T>(T message) where T : class
        {
            await _publishEndpoint.Publish(message);
        }
    }
}
