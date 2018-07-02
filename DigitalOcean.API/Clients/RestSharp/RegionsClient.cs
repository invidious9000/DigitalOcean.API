using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients.RestSharp
{
    public class RegionsClient : IRegionsClient
    {
        private readonly IConnection _connection;

        public RegionsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IRegionsClient Members

        /// <inheritdoc />
        /// <summary>
        /// Retrieve all DigitalOcean regions
        /// </summary>
        public Task<IReadOnlyList<Region>> GetAll(CancellationToken token = default)
        {
            return _connection.GetPaginated<Region>("regions", null, "regions", token);
        }

        #endregion
    }
}