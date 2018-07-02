using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface IFloatingIpActionsClient
    {
        /// <summary>
        /// Assign a Floating IP to a Droplet
        /// </summary>
        Task<FloatingIpAction> Assign(string ipAddress, int dropletId, CancellationToken token = default);

        /// <summary>
        /// Unassign a Floating IP
        /// </summary>
        Task<FloatingIpAction> Unassign(string ipAddress, CancellationToken token = default);

        /// <summary>
        /// Retrieve all actions for a Floating IP
        /// </summary>
        Task<IReadOnlyList<FloatingIpAction>> GetAll(string ipAddress, CancellationToken token = default);

        /// <summary>
        /// Retrieve an action for a Floating IP
        /// </summary>
        Task<FloatingIpAction> GetFloatingIpAction(string ipAddress, int actionId, CancellationToken token = default);
    }
}