using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class KeysClient : IKeysClient
    {
        private readonly IConnection _connection;

        public KeysClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IKeysClient Members

        /// <summary>
        /// Retrieve all keys in your account
        /// </summary>
        public Task<IReadOnlyList<Key>> GetAll(CancellationToken token = default(CancellationToken))
        {
            return _connection.GetPaginated<Key>("account/keys", null, "ssh_keys", token);
        }

        /// <summary>
        /// Create a new key entry
        /// </summary>
        public Task<Key> Create(Models.Requests.Key key, CancellationToken token = default(CancellationToken))
        {
            return _connection.ExecuteRequest<Key>("account/keys", null, key, "ssh_key", Method.POST, token);
        }

        /// <summary>
        /// Retrieve an existing key in your account
        /// </summary>
        public Task<Key> Get(object keyIdOrFingerprint, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = keyIdOrFingerprint, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Key>("account/keys/{id}", parameters, null, "ssh_key", token: token);
        }

        /// <summary>
        /// Update an existing key in your account
        /// </summary>
        public Task<Key> Update(object keyIdOrFingerprint, Models.Requests.Key key, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = keyIdOrFingerprint, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Key>("account/keys/{id}", parameters, key, "ssh_key", Method.PUT, token);
        }

        /// <summary>
        /// Delete an existing key in your account
        /// </summary>
        public Task Delete(object keyIdOrFingerprint, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = keyIdOrFingerprint, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("account/keys/{id}", parameters, null, Method.DELETE, token);
        }

        #endregion
    }
}