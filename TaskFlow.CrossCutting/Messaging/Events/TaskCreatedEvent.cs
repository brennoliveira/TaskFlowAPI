using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.CrossCutting.Messaging.Events
{
    public record TaskCreatedEvent(Guid TaskId, string Title);
}
