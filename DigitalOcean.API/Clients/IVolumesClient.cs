using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IVolumesClient
    {
        /// <summary>
        /// List all Block Storage volumes
        /// </summary>
        Task<IReadOnlyList<Volume>> GetAll(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an existing Block Storage volume
        /// </summary>
        Task<Volume> Get(string volumeId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an existing Block Storage volume by name
        /// </summary>
        Task<Volume> GetByName(string name, string regionSlug, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create a new Block Storage volume
        /// </summary>
        Task<Volume> Create(Models.Requests.Volume volume, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete a Block Storage volume
        /// </summary>
        Task Delete(string volumeId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete a Block Storage volume by name
        /// </summary>
        Task DeleteByName(string name, string regionSlug, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// List snapshots for a volume
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetSnapshotsForVolume(string volumeId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create snapshot from a volume
        /// </summary>
        Task<Snapshot> CreateSnapshotFromVolume(string volumeId, string name, CancellationToken token = default(CancellationToken));
    }
}
