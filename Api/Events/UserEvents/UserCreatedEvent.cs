using System;
using Infrastructure.Events;

namespace Events.UserEvents
{
    public class UserCreatedEvent : Event
    {
        public Guid UserId { get; }

        public UserCreatedEvent(Guid userId)
        {
            UserId = userId;
        }
    }
}