using System.Threading.Tasks;
using Infrastructure.Events;
using Infrastructure.MessageBrokers;
using Infrastructure.Outbox.Stores;
using Newtonsoft.Json;

namespace Infrastructure.Outbox
{
    public class OutboxListener : IOutboxListener
    {
        private readonly IOutboxStore _store;

        public OutboxListener(IOutboxStore store)
        {
            _store = store;
        }

        public async Task Commit(OutboxMessage message)
        {
            await _store.Add(message);
        }

        public async Task Commit<TEvent>(TEvent @event) where TEvent : IEvent
        {
            var outboxMessage = new OutboxMessage
            { 
                Type = MessageBrokerHelpers.GetTypeName<TEvent>(),
                Data = @event == null ? "{}" : JsonConvert.SerializeObject(@event, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                })
            };

            await Commit(outboxMessage);
        }
    }
}