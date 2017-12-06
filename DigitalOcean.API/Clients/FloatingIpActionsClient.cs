using System.Collections.Generic;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients
{
    public class FloatingIpActionsClient : IFloatingIpActionsClient
    {

        private readonly IConnection _connection;

        public FloatingIpActionsClient(IConnection connection)
        {
            _connection = connection;
        }

        public Task<FloatingIpAction> Assign(string ipAddress, int dropletId)
        {
            var fip = new Models.Requests.FloatingIpAction
            {
                Type = "assign_ip",
                DropletId = dropletId
            };
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<FloatingIpAction>("floating_ips/{ip}/actions", parameters, fip, "action", Method.POST);

        }

        public Task<FloatingIpAction> Unassign(string ipAddress)
        {
            var fip = new Models.Requests.FloatingIpAction
            {
                Type = "unassign"
            };
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<FloatingIpAction>("floating_ips/{ip}/actions", parameters, fip, "action", Method.POST);
        }

        public Task<IReadOnlyList<FloatingIpAction>> GetAll(string ipAddress)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<FloatingIpAction>("floating_ips/{ip}/actions", parameters, "actions");
        }

        public Task<FloatingIpAction> GetFloatingIpAction(string ipAddress, int actionId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "ip", Value = ipAddress, Type = ParameterType.UrlSegment},
                new Parameter {Name = "action_id", Value = actionId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<FloatingIpAction>("floating_ips/{ip}/actions/{action_id}", parameters, null, "action");

        }
    }
}