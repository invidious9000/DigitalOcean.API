using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IDomainsClient
    {
        /// <summary>
        /// Retrieve a list of all domains in your account
        /// </summary>
        Task<IReadOnlyList<Domain>> GetAll(CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create a new domain
        /// </summary>
        Task<Domain> Create(Models.Requests.Domain domain, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve a specific domain
        /// </summary>
        Task<Domain> Get(string domainName, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete an existing domain
        /// </summary>
        Task Delete(string domainName, CancellationToken token = default(CancellationToken));
    }
}