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

        /// <summary>
        /// Retrieve all Tags in your account
        /// </summary>
        public Task<IReadOnlyList<Tag>> GetAll( CancellationToken token = default(CancellationToken))
        {
            return _connection.GetPaginated<Tag>("tags", null, "tags", token);
        }

        /// <summary>
        /// Retrieve an individual Tag by name
        /// </summary>
        public Task<Tag> Get(string tagName, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Tag>("tags/{name}", parameters, null, "tag", token: token);
        }

        /// <summary>
        /// Create a new Tag
        /// </summary>
        public Task<Tag> Create(string tagName, CancellationToken token = default(CancellationToken))
        {
            var data = new Models.Requests.Tag
            {
                Name = tagName
            };

            return _connection.ExecuteRequest<Tag>("tags", null, data, "tag", Method.POST, token);
        }

        /// <summary>
        /// Tag existing resources of given resource id / type combination
        /// </summary>
        public Task Tag(string tagName, List<KeyValuePair<string, string>> resources, CancellationToken token = default(CancellationToken))
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

        /// <summary>
        /// Untag existing resources of given resource id / type combination
        /// </summary>
        public Task Untag(string tagName, List<KeyValuePair<string, string>> resources, CancellationToken token = default(CancellationToken))
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

        /// <summary>
        /// Delete an existing Tag
        /// </summary>
        public Task Delete(string tagName, CancellationToken token = default(CancellationToken))
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