using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using RestSharp;

namespace DOcean.API.Clients.RestSharp
{
    public class SnapshotsClient : ISnapshotsClient
    {

        private readonly IConnection _connection;

        public SnapshotsClient(IConnection connection)
        {
            _connection = connection;
        }

        public Task<IReadOnlyList<Snapshot>> GetAll(CancellationToken token = new CancellationToken())
        {
            return _connection.GetPaginated<Snapshot>("snapshots", null, "snapshots", token);
        }

        public Task<IReadOnlyList<Snapshot>> GetAllDropletSnapshots(CancellationToken token = new CancellationToken())
        {
            return _connection.GetPaginated<Snapshot>("snapshots?resource_type=droplet", null, "snapshots", token);
        }

        public Task<IReadOnlyList<Snapshot>> GetAllVolumeSnapshots(CancellationToken token = new CancellationToken())
        {
            return _connection.GetPaginated<Snapshot>("snapshots?resource_type=volume", null, "snapshots", token);
        }

        public Task<Snapshot> Get(string snapshotId, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = snapshotId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRequest<Snapshot>("snapshots/{id}", parameters, null, "snapshot", token: token);
        }

        public Task Delete(string snapshotId, CancellationToken token = new CancellationToken())
        {
            var parameters = new List<Parameter>
            {
                new Parameter {Name = "id", Value = snapshotId, Type = ParameterType.UrlSegment}
            };
            return _connection.ExecuteRaw("snapshots/{id}", parameters, null, Method.DELETE, token);
        }
    }
}
