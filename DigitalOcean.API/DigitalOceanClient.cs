using DOcean.API.Clients;
using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using RestSharp;

namespace DOcean.API
{
    public class DigitalOceanClient : IDigitalOceanClient
    {
        public static readonly string DigitalOceanApiUrl = "https://api.digitalocean.com/v2/";
        private readonly IConnection _connection;

        public DigitalOceanClient(string token)
        {
            var client = new RestClient(DigitalOceanApiUrl)
            {
                UserAgent = "digitalocean-api-dotnet"
            };
            client.AddDefaultHeader("Authorization", $"Bearer {token}");

            _connection = new Connection(client);

            Actions = new ActionsClient(_connection);
            DomainRecords = new DomainRecordsClient(_connection);
            Domains = new DomainsClient(_connection);
            DropletActions = new DropletActionsClient(_connection);
            Droplets = new DropletsClient(_connection);
            FloatingIps = new FloatingIpsClient(_connection);
            FloatingIpActions = new FloatingIpActionsClient(_connection);
            ImageActions = new ImageActionsClient(_connection);
            Images = new ImagesClient(_connection);
            Keys = new KeysClient(_connection);
            Regions = new RegionsClient(_connection);
            Sizes = new SizesClient(_connection);
            Snapshots = new SnapshotsClient(_connection);
            Tags = new TagsClient(_connection);
            Volumes = new VolumesClient(_connection);
        }

        #region IDigitalOceanClient Members

        public IVolumesClient Volumes { get; }
        public IRateLimit Rates => _connection.Rates;

        public IActionsClient Actions { get; }
        public IDomainRecordsClient DomainRecords { get; }
        public IDomainsClient Domains { get; }
        public IDropletActionsClient DropletActions { get; }
        public IDropletsClient Droplets { get; }
        public IFloatingIpsClient FloatingIps { get; }
        public IFloatingIpActionsClient FloatingIpActions { get; }
        public IImageActionsClient ImageActions { get; }
        public IImagesClient Images { get; }
        public IKeysClient Keys { get; }
        public IRegionsClient Regions { get; }
        public ISizesClient Sizes { get; }
        public ISnapshotsClient Snapshots { get; }
        public ITagsClient Tags { get; }

        #endregion
    }
}