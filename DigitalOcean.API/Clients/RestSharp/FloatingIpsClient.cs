using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class FloatingIpsClient : IFloatingIpsClient
    {
        private readonly IConnection _connection;

        public FloatingIpsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IFloatingIpsClient Members

        public Task<IReadOnlyList<FloatingIp>> GetAll(CancellationToken token = default)
        {
            return _connection.GetPaginated<FloatingIp>("floating_ips", null, "floating_ips", token);
        }

        public Task<FloatingIp> Get(string ipAddress, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<FloatingIp>("floating_ips/{ip}", parameters, null, "floating_ip", token: token);
        }

        public Task<FloatingIp> AssignNew(int dropletId, CancellationToken token = default)
        {
            var fip = new Models.Requests.FloatingIp { DropletId = dropletId };
            return _connection.ExecuteRequest<FloatingIp>("floating_ips", null, fip, "floating_ip", Method.POST, token);
        }

        public Task<FloatingIp> Reserve(string regionSlug, CancellationToken token = default)
        {
            var fip = new Models.Requests.FloatingIp { Region = regionSlug };
            return _connection.ExecuteRequest<FloatingIp>("floating_ips", null, fip, "floating_ip", Method.POST, token);
        }

        public Task Delete(string ipAddress, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("floating_ips/{ip}", parameters, null, Method.DELETE, token);
        }

        #endregion
    }
}