using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IDropletActionsClient
    {
        /// <summary>
        /// Reboot a droplet
        /// </summary>
        Task<Action> Reboot(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        Task<Action> PowerCycle(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        Task<Action> Shutdown(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Turn off a droplet
        /// </summary>
        Task<Action> PowerOff(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Turn on a droplet
        /// </summary>
        Task<Action> PowerOn(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        Task<Action> ResetPassword(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Resize a droplet
        /// </summary>
        Task<Action> Resize(int dropletId, string sizeSlug, CancellationToken token = default);

        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        Task<Action> Restore(int dropletId, int imageId, CancellationToken token = default);

        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        Task<Action> Rebuild(int dropletId, object imageIdOrSlug, CancellationToken token = default);

        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        Task<Action> Rename(int dropletId, string name, CancellationToken token = default);

        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        Task<Action> ChangeKernel(int dropletId, int kernelId, CancellationToken token = default);

        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        Task<Action> EnableIpv6(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        Task<Action> DisableBackups(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Enable private networking on a droplet
        /// </summary>
        Task<Action> EnablePrivateNetworking(int dropletId, CancellationToken token = default);

        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        Task<Action> Snapshot(int dropletId, string name, CancellationToken token = default);

        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        Task<Action> GetDropletAction(int dropletId, int actionId, CancellationToken token = default);
    }
}