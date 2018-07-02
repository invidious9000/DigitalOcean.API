using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface ITagsClient
    {
        /// <summary>
        /// Retrieve all Tags in your account
        /// </summary>
        Task<IReadOnlyList<Tag>> GetAll(CancellationToken token = default);

        /// <summary>
        /// Retrieve an individual Tag by name
        /// </summary>
        Task<Tag> Get(string tagName, CancellationToken token = default);

        /// <summary>
        /// Create a new Tag
        /// </summary>
        Task<Tag> Create(string tagName, CancellationToken token = default);

        /// <summary>
        /// Tag existing resources of given resource id / type combination
        /// </summary>
        Task Tag(string tagName, IEnumerable<KeyValuePair<string, string>> resources,
            CancellationToken token = default);

        /// <summary>
        /// Untag existing resources of given resource id / type combination
        /// </summary>
        Task Untag(string tagName, IEnumerable<KeyValuePair<string, string>> resources,
            CancellationToken token = default);

        /// <summary>
        /// Delete an existing Tag
        /// </summary>
        Task Delete(string tagName, CancellationToken token = default);
    }
}