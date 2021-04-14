using System.Threading;
using System.Threading.Tasks;
using Events.UserEvents;
using Infrastructure.Events;

namespace Components.UserComponents.Events
{
    public class UserCreatedHandler
    {
        public class Handler : IEventHandler<UserCreatedEvent>
        {
            public Task Handle(UserCreatedEvent notification, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}