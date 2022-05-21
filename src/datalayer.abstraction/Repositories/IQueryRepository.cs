using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace datalayer.abstraction.Repositories
{
    public interface IQueryRepository<Targ, TResult>
    {
        public Task<TResult> GetByIdAsync(Targ arg, CancellationToken cancellationToken);
    }
}
