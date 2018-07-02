using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IActionsClient
    {
        /// <summary>
        /// Retrieve all actions that have been executed on the current account.
        /// </summary>
        Task<IReadOnlyList<Action>> GetAll(CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing action
        /// </summary>
        Task<Action> Get(int actionId, CancellationToken token = default);
    }
}