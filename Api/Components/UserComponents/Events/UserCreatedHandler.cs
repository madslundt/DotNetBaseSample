using System.Threading;
using System.Threading.Tasks;
using Events.UserEvents;
using Infrastructure.Events;

namespace Components.UserComponents.Events
{
    public class UserCreatedHandler
    {
        public class Handler : IEventHandler<UserCreated>
        {
            public Task Handle(UserCreated notification, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}