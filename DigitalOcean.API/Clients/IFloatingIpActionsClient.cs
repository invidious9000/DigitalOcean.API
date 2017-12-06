using System.Collections.Generic;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IFloatingIpActionsClient
    {
        /// <summary>
        /// Assign a Floating IP to a Droplet
        /// </summary>
        Task<FloatingIpAction> Assign(string ipAddress, int dropletId);

        /// <summary>
        /// Unassign a Floating IP
        /// </summary>
        Task<FloatingIpAction> Unassign(string ipAddress);

        /// <summary>
        /// Retrieve all actions for a Floating IP
        /// </summary>
        Task<IReadOnlyList<FloatingIpAction>> GetAll(string ipAddress);

        /// <summary>
        /// Retrieve an action for a Floating IP
        /// </summary>
        Task<FloatingIpAction> GetFloatingIpAction(string ipAddress, int actionId);
    }
}