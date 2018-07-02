using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients.RestSharp
{
    public class SizesClient : ISizesClient
    {
        private readonly IConnection _connection;

        public SizesClient(IConnection connection)
        {
            _connection = connection;
        }

        #region ISizesClient Members

        /// <inheritdoc />
        /// <summary>
        /// Retrieve all DigitalOcean Droplet Sizes
        /// </summary>
        public Task<IReadOnlyList<Size>> GetAll(CancellationToken token = default)
        {
            return _connection.GetPaginated<Size>("sizes", null, "sizes", token);
        }

        #endregion
    }
}