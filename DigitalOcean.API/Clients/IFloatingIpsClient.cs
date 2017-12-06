using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IFloatingIpsClient
    {
        /// <summary>
        /// Retrieve all Floating IPs in your account
        /// </summary>
        Task<IReadOnlyList<FloatingIp>> GetAll( CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an individual Floating IP by IP address
        /// </summary>
        Task<FloatingIp> Get(string ipAddress, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Assigns a new Floating IP to the specified Droplet
        /// </summary>
        Task<FloatingIp> AssignNew(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Reserves a new Floating IP in the designated Region
        /// </summary>
        Task<FloatingIp> Reserve(string regionSlug, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete an existing Floating IP
        /// </summary>
        Task Delete(string ipAddress, CancellationToken token = default(CancellationToken));
    }
}