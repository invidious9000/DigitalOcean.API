using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    public interface ISizesClient
    {
        /// <summary>
        /// Retrieve all DigitalOcean Droplet Sizes
        /// </summary>
        Task<IReadOnlyList<Size>> GetAll(CancellationToken token = default(CancellationToken));
    }
}