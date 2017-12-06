using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class DomainsClient : IDomainsClient
    {
        private readonly IConnection _connection;

        public DomainsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IDomainsClient Members

        /// <summary>
        /// Retrieve a list of all domains in your account
        /// </summary>
        public Task<IReadOnlyList<Domain>> GetAll(CancellationToken token = default(CancellationToken))
        {
            return _connection.GetPaginated<Domain>("domains", null, "domains", token);
        }

        /// <summary>
        /// Create a new domain
        /// </summary>
        public Task<Domain> Create(Models.Requests.Domain domain, CancellationToken token = default(CancellationToken))
        {
            return _connection.ExecuteRequest<Domain>("domains", null, domain, "domain", Method.POST, token);
        }

        /// <summary>
        /// Retrieve a specific domain
        /// </summary>
        public Task<Domain> Get(string domainName, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = domainName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Domain>("domains/{name}", parameters, null, "domain", token: token);
        }

        /// <summary>
        /// Delete an existing domain
        /// </summary>
        public Task Delete(string domainName, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = domainName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("domains/{name}", parameters, null, Method.DELETE, token);
        }

        #endregion
    }
}