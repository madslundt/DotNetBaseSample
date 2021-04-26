using System;
using System.Threading.Tasks;
using Infrastructure.Events;

namespace Infrastructure.MessageBrokers
{
    public interface IMessageBroker
    {
        void Subscribe(Type type);
        void Subscribe<TEvent>() where TEvent : IEvent;
        Task Publish(IEvent @event);
        Task Publish(string message, string type);
    }
}