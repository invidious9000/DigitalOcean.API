using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public interface IVolumesClient
    {
        /// <summary>
        /// List all Block Storage volumes
        /// </summary>
        Task<IReadOnlyList<Volume>> GetAll(CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing Block Storage volume
        /// </summary>
        Task<Volume> Get(string volumeId, CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing Block Storage volume by name
        /// </summary>
        Task<Volume> GetByName(string name, string regionSlug, CancellationToken token = default);

        /// <summary>
        /// Create a new Block Storage volume
        /// </summary>
        Task<Volume> Create(Models.Requests.Volume volume, CancellationToken token = default);

        /// <summary>
        /// Delete a Block Storage volume
        /// </summary>
        Task Delete(string volumeId, CancellationToken token = default);

        /// <summary>
        /// Delete a Block Storage volume by name
        /// </summary>
        Task DeleteByName(string name, string regionSlug, CancellationToken token = default);

        /// <summary>
        /// List snapshots for a volume
        /// </summary>
        Task<IReadOnlyList<Snapshot>> GetSnapshotsForVolume(string volumeId, CancellationToken token = default);

        /// <summary>
        /// Create snapshot from a volume
        /// </summary>
        Task<Snapshot> CreateSnapshotFromVolume(string volumeId, string name, CancellationToken token = default);
    }
}