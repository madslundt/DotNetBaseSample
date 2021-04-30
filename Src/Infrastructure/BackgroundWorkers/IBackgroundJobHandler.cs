using MediatR;

namespace Infrastructure.BackgroundWorkers
{
    public interface IBackgroundJobHandler<T> : INotificationHandler<T> where T : IBackgroundJob
    {
        
    }
}