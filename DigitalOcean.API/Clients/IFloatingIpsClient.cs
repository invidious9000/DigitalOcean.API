using System.Collections.Generic;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IFloatingIpsClient
    {
        /// <summary>
        /// Retrieve all Floating IPs in your account
        /// </summary>
        Task<IReadOnlyList<FloatingIp>> GetAll();

        /// <summary>
        /// Retrieve an individual Floating IP by IP address
        /// </summary>
        Task<FloatingIp> Get(string ipAddress);

        /// <summary>
        /// Assigns a new Floating IP to the specified Droplet
        /// </summary>
        Task<FloatingIp> AssignNew(int dropletId);

        /// <summary>
        /// Reserves a new Floating IP in the designated Region
        /// </summary>
        Task<FloatingIp> Reserve(string regionSlug);

        /// <summary>
        /// Delete an existing Floating IP
        /// </summary>
        Task Delete(string ipAddress);
    }
}