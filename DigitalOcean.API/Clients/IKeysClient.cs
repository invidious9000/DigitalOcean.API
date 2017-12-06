using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IKeysClient
    {
        /// <summary>
        /// Retrieve all keys in your account
        /// </summary>
        Task<IReadOnlyList<Key>> GetAll( CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create a new key entry
        /// </summary>
        Task<Key> Create(Models.Requests.Key key, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an existing key in your account
        /// </summary>
        Task<Key> Get(object keyIdOrFingerprint, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Update an existing key in your account
        /// </summary>
        Task<Key> Update(object keyIdOrFingerprint, Models.Requests.Key key, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete an existing key in your account
        /// </summary>
        Task Delete(object keyIdOrFingerprint, CancellationToken token = default(CancellationToken));
    }
}