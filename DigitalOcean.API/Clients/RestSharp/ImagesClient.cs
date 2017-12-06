using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Requests;
using RestSharp;
using Image = DOcean.API.Models.Responses.Image;

namespace DOcean.API.Clients.RestSharp
{
    public class ImagesClient : IImagesClient
    {
        private readonly IConnection _connection;

        public ImagesClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IImagesClient Members

        /// <summary>
        /// Retrieve all images available on your account.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetAll(ImageType type = ImageType.All, CancellationToken token = default(CancellationToken))
        {
            var endpoint = "images";
            switch (type)
            {
                case ImageType.All:
                    break;
                case ImageType.Application:
                    endpoint += "?type=" + type.ToString().ToLower();
                    break;
                case ImageType.Distribution:
                    endpoint += "?type=" + type.ToString().ToLower();
                    break;
                case ImageType.Private:
                    endpoint += "?private=true";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
            return _connection.GetPaginated<Image>(endpoint, null, "images", token);
        }

        /// <summary>
        /// Retrieve information about a public or private image on your account.
        /// </summary>
        /// <remarks>
        /// You can only retrieve information about public images when using a slug.
        /// </remarks>
        public Task<Image> Get(object imageIdOrSlug, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = imageIdOrSlug, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Image>("images/{id}", parameters, null, "image", token: token);
        }

        /// <summary>
        /// Delete an existing image
        /// </summary>
        public Task Delete(int imageId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = imageId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("images/{id}", parameters, null, Method.DELETE, token);
        }

        /// <summary>
        /// Update an existing image
        /// </summary>
        public Task<Image> Update(int imageId, Models.Requests.Image image, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = imageId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Image>("images/{id}", parameters, image, "image", Method.PUT, token);
        }

        #endregion
    }
}