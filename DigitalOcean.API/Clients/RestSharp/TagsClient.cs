using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Requests;
using RestSharp;
using Tag = DOcean.API.Models.Responses.Tag;

namespace DOcean.API.Clients.RestSharp
{
    public class TagsClient : ITagsClient
    {
        private readonly IConnection _connection;

        public TagsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region ITagsClient Members

        /// <inheritdoc />
        /// <summary>
        /// Retrieve all Tags in your account
        /// </summary>
        public Task<IReadOnlyList<Tag>> GetAll( CancellationToken token = default)
        {
            return _connection.GetPaginated<Tag>("tags", null, "tags", token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve an individual Tag by name
        /// </summary>
        public Task<Tag> Get(string tagName, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Tag>("tags/{name}", parameters, null, "tag", token: token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a new Tag
        /// </summary>
        public Task<Tag> Create(string tagName, CancellationToken token = default)
        {
            var data = new Models.Requests.Tag
            {
                Name = tagName
            };

            return _connection.ExecuteRequest<Tag>("tags", null, data, "tag", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Tag existing resources of given resource id / type combination
        /// </summary>
        public Task Tag(string tagName, IEnumerable<KeyValuePair<string, string>> resources, CancellationToken token = default)
        {
            var data = new TagResource
            {
                Resources = new List<TagResource.Resource>()
            };

            foreach (var resource in resources)
                data.Resources.Add(new TagResource.Resource
                {
                    Id = resource.Key,
                    Type = resource.Value
                });

            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };

            return _connection.ExecuteRaw("tags/{name}/resources", parameters, data, Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Untag existing resources of given resource id / type combination
        /// </summary>
        public Task Untag(string tagName, IEnumerable<KeyValuePair<string, string>> resources, CancellationToken token = default)
        {
            var data = new TagResource
            {
                Resources = new List<TagResource.Resource>()
            };

            foreach (var resource in resources)
                data.Resources.Add(new TagResource.Resource
                {
                    Id = resource.Key,
                    Type = resource.Value
                });

            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };

            return _connection.ExecuteRaw("tags/{name}/resources", parameters, data, Method.DELETE, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Delete an existing Tag
        /// </summary>
        public Task Delete(string tagName, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("tags/{name}", parameters, null, Method.DELETE, token);
        }

        #endregion
    }
}