using MediatR;

namespace businesslogic.abstraction.Contracts
{
    public interface ICommandRequest<out TResponce> : IRequest<TResponce>
    {
    }
}
