using MediatR;

namespace Infrastructure.Queries
{
    public interface IQuery<out TResponse> : IRequest<TResponse>
    {
    }
}