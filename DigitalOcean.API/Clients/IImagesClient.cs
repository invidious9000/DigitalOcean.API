using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Requests;
using Image = DOcean.API.Models.Responses.Image;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IImagesClient
    {
        /// <summary>
        /// Retrieve all images available ony your account.
        /// </summary>
        Task<IReadOnlyList<Image>> GetAll(ImageType type = ImageType.All, CancellationToken token = default);

        /// <summary>
        /// Retrieve information about a public or private image on your account.
        /// </summary>
        /// <remarks>
        /// You can only retrieve information about public images when using a slug.
        /// </remarks>
        Task<Image> Get(object imageIdOrSlug, CancellationToken token = default);

        /// <summary>
        /// Delete an existing image
        /// </summary>
        Task Delete(int imageId, CancellationToken token = default);

        /// <summary>
        /// Update an existing image
        /// </summary>
        Task<Image> Update(int imageId, Models.Requests.Image image, CancellationToken token = default);
    }
}