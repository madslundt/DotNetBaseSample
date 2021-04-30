using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Hangfire;
using MediatR;

namespace Infrastructure.BackgroundWorkers.Hangfire
{
    public class HangfireBackgroundJobBus : IBackgroundJobBus
    {
        private readonly IMediator _mediator;

        public HangfireBackgroundJobBus(IMediator mediator)
        {
            _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
        }

        [DisplayName("{0}")]
        public void Enqueue(params IBackgroundJob[] jobs)
        {
            foreach (var job in jobs)
            {
                Enqueue(job);
            }
        }

        public void Schedule(TimeSpan timeSpan, params IBackgroundJob[] jobs)
        {
            foreach (var job in jobs)
            {
                Schedule(job, timeSpan);
            }
        }

        private void Schedule(IBackgroundJob request, TimeSpan timeSpan)
        {
            var client = new BackgroundJobClient();
            client.Schedule<MediatorHangfireBridge>(bus => bus.Enqueue(request), timeSpan);
        }

        private void Enqueue(IBackgroundJob request)
        {
            var client = new BackgroundJobClient();
            client.Enqueue<MediatorHangfireBridge>(bus => bus.Enqueue(request));
        }
    }
}