using System.Threading;
using System.Threading.Tasks;

namespace businesslogic.abstraction.Services
{
    public interface IQueryService<Targ, TResult>
    {
        public Task<TResult> GetByIdAsync(Targ arg, CancellationToken cancellationToken);
    }
}
