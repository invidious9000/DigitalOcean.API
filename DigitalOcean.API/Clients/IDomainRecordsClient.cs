using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface IDomainRecordsClient
    {
        /// <summary>
        /// Retrieve all records configured for a domain
        /// </summary>
        Task<IReadOnlyList<DomainRecord>> GetAll(string domainName, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Create a new record for a domain.
        /// </summary>
        Task<DomainRecord> Create(string domainName, Models.Requests.DomainRecord record, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Retrieve a specific domain record
        /// </summary>
        Task<DomainRecord> Get(string domainName, int recordId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Delete a record for a domain
        /// </summary>
        Task Delete(string domainName, int recordId, CancellationToken token = default(CancellationToken));

        /// <summary>
        /// Update an existing record for a domain
        /// </summary>
        Task<DomainRecord> Update(string domainName, int recordId, Models.Requests.DomainRecord newRecord, CancellationToken token = default(CancellationToken));
    }
}