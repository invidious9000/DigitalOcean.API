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
    public interface IFloatingIpsClient
    {
        /// <summary>
        /// Retrieve all Floating IPs in your account
        /// </summary>
        Task<IReadOnlyList<FloatingIp>> GetAll( CancellationToken token = default);

        /// <summary>
        /// Retrieve an individual Floating IP by IP address
        /// </summary>
        Task<FloatingIp> Get(string ipAddress, CancellationToken token = default);

        /// <summary>
        /// Assigns a new Floating IP to the specified Droplet
        /// </summary>
        Task<FloatingIp> AssignNew(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Reserves a new Floating IP in the designated Region
        /// </summary>
        Task<FloatingIp> Reserve(string regionSlug, CancellationToken token = default);

        /// <summary>
        /// Delete an existing Floating IP
        /// </summary>
        Task Delete(string ipAddress, CancellationToken token = default);
    }
}