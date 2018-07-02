using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IKeysClient
    {
        /// <summary>
        /// Retrieve all keys in your account
        /// </summary>
        Task<IReadOnlyList<Key>> GetAll(CancellationToken token = default);

        /// <summary>
        /// Create a new key entry
        /// </summary>
        Task<Key> Create(Models.Requests.Key key, CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing key in your account
        /// </summary>
        Task<Key> Get(object keyIdOrFingerprint, CancellationToken token = default);

        /// <summary>
        /// Update an existing key in your account
        /// </summary>
        Task<Key> Update(object keyIdOrFingerprint, Models.Requests.Key key, CancellationToken token = default);

        /// <summary>
        /// Delete an existing key in your account
        /// </summary>
        Task Delete(object keyIdOrFingerprint, CancellationToken token = default);
    }
}