using System.Threading.Tasks;

namespace Infrastructure.Events
{
    public interface IEventBus
    {
        Task Commit(params IEvent[] events);
    }
}