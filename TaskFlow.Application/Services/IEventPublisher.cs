using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Application.Services
{
    internal interface IEventPublisher
    {
        Task PublishEventAsync<T>(T message) where T : class;
    }
}
