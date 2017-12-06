using DOcean.API.Clients;
using DOcean.API.Http;

namespace DOcean.API
{
    public interface IDigitalOceanClient
    {
        IActionsClient Actions { get; }
        IDomainRecordsClient DomainRecords { get; }
        IDomainsClient Domains { get; }
        IDropletActionsClient DropletActions { get; }
        IDropletsClient Droplets { get; }
        IFloatingIpsClient FloatingIps { get; }
        IFloatingIpActionsClient FloatingIpActions { get; }
        IImageActionsClient ImageActions { get; }
        IImagesClient Images { get; }
        IKeysClient Keys { get; }
        IRegionsClient Regions { get; }
        ISizesClient Sizes { get; }

        IRateLimit Rates { get; }
        ITagsClient Tags { get; }
    }
}