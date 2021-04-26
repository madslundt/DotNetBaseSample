using System.Threading.Tasks;

namespace Infrastructure.Events
{
    public interface IEventBus
    {
        Task Enqueue(params IEvent[] events);
        Task Commit(params IEvent[] events);
    }
}