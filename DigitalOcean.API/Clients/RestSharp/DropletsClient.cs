using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class DropletsClient : IDropletsClient
    {
        private readonly IConnection _connection;

        public DropletsClient(IConnection connection)
        {
            _connection = connection;
        }

        #region IDropletsClient Members

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> GetAll(CancellationToken token = default(CancellationToken))
        {
            return _connection.GetPaginated<Droplet>("droplets", null, "droplets", token);
        }

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> GetAllByTag(string tagName, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Droplet>("droplets?tag_name={name}", parameters, "droplets", token);
        }

        /// <summary>
        /// Retrieve all kernels available to a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Kernel>> GetKernels(int dropletId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Kernel>("droplets/{id}/kernels", parameters, "kernels", token);
        }

        /// <summary>
        /// Retrieve all snapshots that have been created for a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetSnapshots(int dropletId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Image>("droplets/{id}/snapshots", parameters, "snapshots", token);
        }

        /// <summary>
        /// Retrieve all backups that have been created for a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetBackups(int dropletId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Image>("droplets/{id}/backups", parameters, "backups", token);
        }

        /// <summary>
        /// Retrieve all actions that have been executed on a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Action>> GetActions(int dropletId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Action>("droplets/{id}/actions", parameters, "actions", token);
        }

        /// <summary>
        /// Create a new Droplet
        /// </summary>
        public Task<Droplet> Create(Models.Requests.Droplet droplet, CancellationToken token = default(CancellationToken))
        {
            return _connection.ExecuteRequest<Droplet>("droplets", null, droplet, "droplet", Method.POST, token);
        }

        /// <summary>
        /// Retrieve an existing Droplet
        /// </summary>
        public Task<Droplet> Get(int dropletId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Droplet>("droplets/{id}", parameters, null, "droplet", token: token);
        }

        /// <summary>
        /// Delete an existing Droplet
        /// </summary>
        public Task Delete(int dropletId, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("droplets/{id}", parameters, null, Method.DELETE, token);
        }

        /// <summary>
        /// Delete existing droplets by tag
        /// </summary>
        public Task DeleteByTag(string tagName, CancellationToken token = default(CancellationToken))
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("droplets?tag_name={name}", parameters, null, Method.DELETE, token);
        }

        /// <summary>
        /// Retrieve a list of droplets that are scheduled to be upgraded
        /// </summary>
        public Task<IReadOnlyList<DropletUpgrade>> GetUpgrades(CancellationToken token = default(CancellationToken))
        {
            return _connection.GetPaginated<DropletUpgrade>("droplet_upgrades", null, token: token);
        }

        #endregion
    }
}