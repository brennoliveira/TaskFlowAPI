using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Events
{
    public record TaskOpenedEvent(Guid TaskId, Guid UserId, DateTime OpenedAt);
}
