using MediatR;

namespace businesslogic.abstraction.Contracts
{
    public interface IQueryRequest<out TResponce> : IRequest<TResponce>
    {
    }
}
