using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface ITagsClient
    {
        /// <summary>
        /// Retrieve all Tags in your account
        /// </summary>
        Task<IReadOnlyList<Tag>> GetAll(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an individual Tag by name
        /// </summary>
        Task<Tag> Get(string tagName, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create a new Tag
        /// </summary>
        Task<Tag> Create(string tagName, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Tag existing resources of given resource id / type combination
        /// </summary>
        Task Tag(string tagName, List<KeyValuePair<string, string>> resources, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Untag existing resources of given resource id / type combination
        /// </summary>
        Task Untag(string tagName, List<KeyValuePair<string, string>> resources, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete an existing Tag
        /// </summary>
        Task Delete(string tagName, CancellationToken token = default(CancellationToken));
    }
}