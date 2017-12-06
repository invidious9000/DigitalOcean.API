using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IActionsClient
    {
        /// <summary>
        /// Retrieve all actions that have been executed on the current account.
        /// </summary>
        Task<IReadOnlyList<Action>> GetAll(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an existing action
        /// </summary>
        Task<Action> Get(int actionId, CancellationToken token = default(CancellationToken));
    }
}