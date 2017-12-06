using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IDropletActionsClient
    {
        /// <summary>
        /// Reboot a droplet
        /// </summary>
        Task<Action> Reboot(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        Task<Action> PowerCycle(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        Task<Action> Shutdown(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Turn off a droplet
        /// </summary>
        Task<Action> PowerOff(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Turn on a droplet
        /// </summary>
        Task<Action> PowerOn(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        Task<Action> ResetPassword(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Resize a droplet
        /// </summary>
        Task<Action> Resize(int dropletId, string sizeSlug, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        Task<Action> Restore(int dropletId, int imageId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        Task<Action> Rebuild(int dropletId, object imageIdOrSlug, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        Task<Action> Rename(int dropletId, string name, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        Task<Action> ChangeKernel(int dropletId, int kernelId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        Task<Action> EnableIpv6(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        Task<Action> DisableBackups(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Enable private networking on a droplet
        /// </summary>
        Task<Action> EnablePrivateNetworking(int dropletId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        Task<Action> Snapshot(int dropletId, string name, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        Task<Action> GetDropletAction(int dropletId, int actionId, CancellationToken token = default(CancellationToken));
    }
}