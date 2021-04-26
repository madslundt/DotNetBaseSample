using System.Threading.Tasks;
using Infrastructure.Events;

namespace Infrastructure.Outbox
{
    public interface IOutboxListener
    {
        Task Commit(OutboxMessage message);
        Task Commit<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}