using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IImageActionsClient
    {
        /// <summary>
        /// Transfer an Image to another region
        /// </summary>
        Task<Action> Transfer(int imageId, string regionSlug, CancellationToken token = default);

        /// <summary>
        /// Retrieve an existing Image Action
        /// </summary>
        Task<Action> GetAction(int imageId, int actionId, CancellationToken token = default);
    }
}