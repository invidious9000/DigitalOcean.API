﻿using System.Collections.Generic;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients
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
        public Task<IReadOnlyList<Droplet>> GetAll()
        {
            return _connection.GetPaginated<Droplet>("droplets", null, "droplets");
        }

        /// <summary>
        /// Retrieve all Droplets in your account.
        /// </summary>
        public Task<IReadOnlyList<Droplet>> GetAllByTag(string tagName)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };

            return _connection.GetPaginated<Droplet>("droplets?tag_name={name}", parameters, "droplets");
        }

        /// <summary>
        /// Retrieve all kernels available to a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Kernel>> GetKernels(int dropletId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Kernel>("droplets/{id}/kernels", parameters, "kernels");
        }

        /// <summary>
        /// Retrieve all snapshots that have been created for a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetSnapshots(int dropletId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Image>("droplets/{id}/snapshots", parameters, "snapshots");
        }

        /// <summary>
        /// Retrieve all backups that have been created for a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Image>> GetBackups(int dropletId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Image>("droplets/{id}/backups", parameters, "backups");
        }

        /// <summary>
        /// Retrieve all actions that have been executed on a Droplet.
        /// </summary>
        public Task<IReadOnlyList<Action>> GetActions(int dropletId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Action>("droplets/{id}/actions", parameters, "actions");
        }

        /// <summary>
        /// Create a new Droplet
        /// </summary>
        public Task<Droplet> Create(Models.Requests.Droplet droplet)
        {
            return _connection.ExecuteRequest<Droplet>("droplets", null, droplet, "droplet", Method.POST);
        }

        /// <summary>
        /// Retrieve an existing Droplet
        /// </summary>
        public Task<Droplet> Get(int dropletId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Droplet>("droplets/{id}", parameters, null, "droplet");
        }

        /// <summary>
        /// Delete an existing Droplet
        /// </summary>
        public Task Delete(int dropletId)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = dropletId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("droplets/{id}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Delete existing droplets by tag
        /// </summary>
        public Task DeleteByTag(string tagName)
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = tagName, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("droplets?tag_name={name}", parameters, null, Method.DELETE);
        }

        /// <summary>
        /// Retrieve a list of droplets that are scheduled to be upgraded
        /// </summary>
        public Task<IReadOnlyList<DropletUpgrade>> GetUpgrades()
        {
            return _connection.GetPaginated<DropletUpgrade>("droplet_upgrades", null);
        }

        #endregion
    }
}