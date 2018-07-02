using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Models.Responses;

namespace DOcean.API.Clients
{
    [SuppressMessage("ReSharper", "UnusedMethodReturnValue.Global")]
    [SuppressMessage("ReSharper", "UnusedMemberInSuper.Global")]
    public interface IRegionsClient
    {
        /// <summary>
        /// Retrieve all DigitalOcean regions
        /// </summary>
        Task<IReadOnlyList<Region>> GetAll(CancellationToken token = default);
    }
}