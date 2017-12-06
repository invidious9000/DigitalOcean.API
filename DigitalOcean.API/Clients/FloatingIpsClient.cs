using System.Collections.Generic;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients
{
    public class FloatingIpsClient : IFloatingIpsClient
    {
        private readonly IConnection _connection;

        public FloatingIpsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IFloatingIpsClient Members

        public Task<IReadOnlyList<FloatingIp>> GetAll()
        {
            return _connection.GetPaginated<FloatingIp>("floating_ips", null, "floating_ips");
        }

        public Task<FloatingIp> Get(string ipAddress)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<FloatingIp>("floating_ips/{ip}", parameters, null, "floating_ip");
        }

        public Task<FloatingIp> AssignNew(int dropletId)
        {
            var fip = new Models.Requests.FloatingIp {DropletId = dropletId};
            return _connection.ExecuteRequest<FloatingIp>("floating_ips", null, fip, "floating_ip", Method.POST);
        }

        public Task<FloatingIp> Reserve(string regionSlug)
        {
            var fip = new Models.Requests.FloatingIp {Region = regionSlug};
            return _connection.ExecuteRequest<FloatingIp>("floating_ips", null, fip, "floating_ip", Method.POST);
        }

        public Task Delete(string ipAddress)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("floating_ips/{ip}", parameters, null, Method.DELETE);
        }

        #endregion
    }
}