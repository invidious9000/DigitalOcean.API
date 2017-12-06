using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class VolumesClient : IVolumesClient
    {
        private readonly IConnection _connection;

        public VolumesClient(IConnection connection)
        {
            _connection = connection;
        }

        public Task<IReadOnlyList<Volume>> GetAll(CancellationToken token = new CancellationToken())
        {
            return _connection.GetPaginated<Volume>("volumes", null, "volumes", token);
        }

        public Task<Volume> Get(string volumeId, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = volumeId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Volume>("volumes/{id}", parameters, null, "volume", token: token);
        }

        public Task<Volume> GetByName(string name, string regionSlug, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = name, Type = ParameterType.UrlSegment},
                new Parameter {Name = "region", Value = regionSlug, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Volume>("volumes?name={name}&region={region}", parameters, null, "volumes", token: token);
        }

        public Task<Volume> Create(Models.Requests.Volume volume, CancellationToken token = new CancellationToken())
        {
            return _connection.ExecuteRequest<Volume>("volumes", null, volume, "volume", Method.POST, token);
        }

        public Task Delete(string volumeId, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = volumeId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("volumes/{id}", parameters, null, Method.DELETE, token);
        }

        public Task DeleteByName(string name, string regionSlug, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "name", Value = name, Type = ParameterType.UrlSegment},
                new Parameter {Name = "region", Value = regionSlug, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Volume>("volumes?name={name}&region={region}", parameters, null, "volumes", Method.DELETE, token);
        }

        public Task<IReadOnlyList<Snapshot>> GetSnapshotsForVolume(string volumeId, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = volumeId, Type = ParameterType.UrlSegment}
            };
            return _connection.GetPaginated<Snapshot>("volumes/{id}/snapshots", parameters, "snapshots", token);
        }

        public Task<Snapshot> CreateSnapshotFromVolume(string volumeId, string name, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = volumeId, Type = ParameterType.UrlSegment}
            };
            var snapshot = new Snapshot
            {
                Name = name
            };
            return _connection.ExecuteRequest<Snapshot>("volumes/{id}/snapshots", parameters, snapshot, "snapshot", Method.POST, token);
        }
    }
}
