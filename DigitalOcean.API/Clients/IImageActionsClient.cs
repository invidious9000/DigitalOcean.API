using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IImageActionsClient
    {
        /// <summary>
        /// Transfer an Image to another region
        /// </summary>
        Task<Action> Transfer(int imageId, string regionSlug, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve an existing Image Action
        /// </summary>
        Task<Action> GetAction(int imageId, int actionId, CancellationToken token = default(CancellationToken));
    }
}