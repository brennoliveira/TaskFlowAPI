using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.CrossCutting.Messaging
{
    public class MassTransitEventPublisher(IPublishEndpoint publishEndpoint)
    {
        private readonly IPublishEndpoint _publishEndpoint = publishEndpoint;

        public Task PublishAsync<T>(T message) where T : class
        {
            return _publishEndpoint.Publish(message);
        }   
    }
}
