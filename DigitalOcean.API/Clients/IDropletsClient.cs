using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IDropletsClient
    {
        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAll(CancellationToken token = default);

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        Task<IReadOnlyList<Droplet>> GetAllByTag(string tagName, CancellationToken token = default);

        /// <summary>
        /// Retrieve all kernels available to a Droplet.
        /// </summary>
        Task<IReadOnlyList<Kernel>> GetKernels(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Retrieve all snapshots that have been created for a Droplet.
        /// </summary>
        Task<IReadOnlyList<Image>> GetSnapshots(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Retrieve all backups that have been created for a Droplet.
        /// </summary>
        Task<IReadOnlyList<Image>> GetBackups(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Retrieve all actions that have been executed on a Droplet.
        /// </summary>
        Task<IReadOnlyList<Action>> GetActions(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Create a new Droplet
        /// </summary>
        Task<Droplet> Create(Models.Requests.Droplet droplet, CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing Droplet
        /// </summary>
        Task<Droplet> Get(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Delete an existing Droplet
        /// </summary>
        Task Delete(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Delete existing droplets by tag
        /// </summary>
        Task DeleteByTag(string tagName, CancellationToken token = default);

        /// <summary>
        /// Retrieve a list of droplets that are scheduled to be upgraded
        /// </summary>
        Task<IReadOnlyList<DropletUpgrade>> GetUpgrades(CancellationToken token = default);
    }
}