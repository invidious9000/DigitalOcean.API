using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using RestSharp;
using Action = DOcean.API.Models.Responses.Action;

namespace DOcean.API.Clients.RestSharp
{
    public class ImageActionsClient : IImageActionsClient
    {
        private readonly IConnection _connection;

        public ImageActionsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IImageActionsClient Members

        /// <summary>
        /// Transfer an Image to another region
        /// </summary>
        public Task<Action> Transfer(int imageId, string regionSlug, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "imageId", Value = imageId, Type = ParameterType.UrlSegment}
            };

            var body = new Models.Requests.Action
            {
                Type = "transfer",
                RegionSlug = regionSlug
            };

            return _connection.ExecuteRequest<Action>("images/{imageId}/actions", parameters, body, "action",
                Method.POST, token);
        }

        /// <summary>
        /// Retrieve an existing Image Action
        /// </summary>
        public Task<Action> GetAction(int imageId, int actionId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "imageId", Value = imageId, Type = ParameterType.UrlSegment},
                new Parameter {Name = "actionId", Value = actionId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Action>("images/{imageId}/actions/{actionId}", parameters, null,
                "action", token: token);
        }

        #endregion
    }
}