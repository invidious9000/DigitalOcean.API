using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface ISnapshotsClient
    {
        /// <summary>
        /// List all snapshots
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAll(CancellationToken token = default);

        /// <summary>
        /// List all Droplet snapshots
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAllDropletSnapshots(CancellationToken token = default);

        /// <summary>
        /// List all Volume snapshots
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAllVolumeSnapshots(CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing snapshot by id
        /// </summary>
        Task<Snapshot> Get(string snapshotId, CancellationToken token = default);

        /// <summary>
        /// Delete a snapshot
        /// </summary>
        Task Delete(string snapshotId, CancellationToken token = default);
    }
}