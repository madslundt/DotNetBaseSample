using MediatR;

namespace Infrastructure.Events
{
    public interface IEventHandler<T> : INotificationHandler<T> where T : IEvent
    {
    }
}