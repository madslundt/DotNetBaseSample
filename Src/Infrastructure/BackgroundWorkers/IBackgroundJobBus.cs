using System;
using System.Threading.Tasks;

namespace Infrastructure.BackgroundWorkers
{
    public interface IBackgroundJobBus
    {
        void Enqueue(params IBackgroundJob[] jobs);
        void Schedule(TimeSpan timeSpan, params IBackgroundJob[] jobs);
    }
}