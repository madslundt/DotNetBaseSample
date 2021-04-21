using System;
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
                Console.WriteLine($"User created with id '{notification.UserId}'");

                return Task.CompletedTask;
            }
        }
    }
}