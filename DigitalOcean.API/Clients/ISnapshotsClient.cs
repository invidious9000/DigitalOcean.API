using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface ISnapshotsClient
    {
        /// <summary>
        /// List all snapshots
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAll(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// List all Droplet snapshots
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAllDropletSnapshots(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// List all Volume snapshots
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetAllVolumeSnapshots(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an existing snapshot by id
        /// </summary>
        Task<Snapshot> Get(string snapshotId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete a snapshot
        /// </summary>
        Task Delete(string snapshotId, CancellationToken token = default(CancellationToken));
    }
}
