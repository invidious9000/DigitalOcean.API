using System.Collections.Generic;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public class SizesClient : ISizesClient
    {
        private readonly IConnection _connection;

        public SizesClient(IConnection connection)
        {
            _connection = connection;
        }

        #region ISizesClient Members

        /// <summary>
        /// Retrieve all DigitalOcean Droplet Sizes
        /// </summary>
        public Task<IReadOnlyList<Size>> GetAll()
        {
            return _connection.GetPaginated<Size>("sizes", null, "sizes");
        }

        #endregion
    }
}