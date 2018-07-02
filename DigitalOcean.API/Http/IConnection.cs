using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using RestSharp;

namespace DOcean.API.Http
{
    public interface IConnection
    {
        // ReSharper disable once UnusedMemberInSuper.Global
        IRestClient Client { get; }
        IRateLimit Rates { get; }

        Task<IRestResponse> ExecuteRaw(string endpoint, IEnumerable<Parameter> parameters, object data = null,
            Method method = Method.GET, CancellationToken token = default);

        Task<T> ExecuteRequest<T>(string endpoint, IEnumerable<Parameter> parameters,
            object data = null, string expectedRoot = null, Method method = Method.GET,
            CancellationToken token = default) where T : new();

        Task<IReadOnlyList<T>> GetPaginated<T>(string endpoint, IEnumerable<Parameter> parameters,
            string expectedRoot = null, CancellationToken token = default) where T : new();
    }
}