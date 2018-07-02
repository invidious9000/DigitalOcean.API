using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IDomainsClient
    {
        /// <summary>
        /// Retrieve a list of all domains in your account
        /// </summary>
        Task<IReadOnlyList<Domain>> GetAll(CancellationToken token = default);

        /// <summary>
        /// Create a new domain
        /// </summary>
        Task<Domain> Create(Models.Requests.Domain domain, CancellationToken token = default);

        /// <summary>
        /// Retrieve a specific domain
        /// </summary>
        Task<Domain> Get(string domainName, CancellationToken token = default);

        /// <summary>
        /// Delete an existing domain
        /// </summary>
        Task Delete(string domainName, CancellationToken token = default);
    }
}