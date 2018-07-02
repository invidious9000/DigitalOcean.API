using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class DropletActionsClient : IDropletActionsClient
    {
        private readonly IConnection _connection;

        public DropletActionsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IDropletActions Members

        /// <inheritdoc />
        /// <summary>
        /// Reboot a droplet
        /// </summary>
        public Task<Action> Reboot(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "reboot"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Power cycle a droplet
        /// </summary>
        public Task<Action> PowerCycle(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "power_cycle"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Shutdown a droplet
        /// </summary>
        public Task<Action> Shutdown(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "shutdown"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Turn off a droplet
        /// </summary>
        public Task<Action> PowerOff(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "power_off"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Turn on a droplet
        /// </summary>
        public Task<Action> PowerOn(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "power_on"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Reset the root password of the droplet
        /// </summary>
        public Task<Action> ResetPassword(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "password_reset"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Resize a droplet
        /// </summary>
        public Task<Action> Resize(int dropletId, string sizeSlug, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action
            {
                Type = "resize",
                SizeSlug = sizeSlug
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Restore a droplet using an image
        /// A Droplet restoration will rebuild an image using a backup image. The image ID that is passed in must be a backup of
        /// the current Droplet instance. The operation will leave any embedded SSH keys intact.
        /// </summary>
        public Task<Action> Restore(int dropletId, int imageId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action
            {
                Type = "restore",
                ImageIdOrSlug = imageId
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Rebuild a droplet
        /// </summary>
        public Task<Action> Rebuild(int dropletId, object imageIdOrSlug, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action
            {
                Type = "rebuild",
                ImageIdOrSlug = imageIdOrSlug
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Rename a droplets hostname
        /// </summary>
        public Task<Action> Rename(int dropletId, string name, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action
            {
                Type = "rename",
                Name = name
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Chane the kernel of a droplet
        /// </summary>
        public Task<Action> ChangeKernel(int dropletId, int kernelId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action
            {
                Type = "change_kernel",
                KernelId = kernelId
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Enable IPv6 networking on a droplet
        /// </summary>
        public Task<Action> EnableIpv6(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "enable_ipv6"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Disable backups on a droplet
        /// </summary>
        public Task<Action> DisableBackups(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "disable_backups"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Enable private networking on a droplet
        /// </summary>
        public Task<Action> EnablePrivateNetworking(int dropletId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action {Type = "enable_private_networking"};
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Create a snapshot of a droplet
        /// </summary>
        public Task<Action> Snapshot(int dropletId, string name, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            var body = new Models.Requests.Action
            {
                Type = "snapshot",
                Name = name
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions", parameters, body,
                "action", Method.POST, token);
        }

        /// <inheritdoc />
        /// <summary>
        /// Retrieve an action for a droplet
        /// </summary>
        public Task<Action> GetDropletAction(int dropletId, int actionId, CancellationToken token = default)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "dropletId", Value = dropletId, Type = ParameterType.UrlSegment},
                new Parameter {Name = "actionId", Value = actionId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Action>("droplets/{dropletId}/actions/{actionId}", parameters,
                null, "action", token: token);
        }

        #endregion
    }
}