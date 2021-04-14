using System;
using Infrastructure.Events;

namespace Events.UserEvents
{
    public class UserCreated : Event
    {
        public Guid UserId { get; }

        public UserCreated(Guid userId)
        {
            UserId = userId;
        }
    }
}