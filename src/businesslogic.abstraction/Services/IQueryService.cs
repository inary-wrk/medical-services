using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using businesslogic.abstraction.TinyTypes;

namespace businesslogic.abstraction.Services
{
    public interface IQueryService<Targ, TResult>
    {
        public Task<TResult> GetByIdAsync(Targ arg, CancellationToken cancellationToken);
    }
}
