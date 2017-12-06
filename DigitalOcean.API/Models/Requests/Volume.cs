using Newtonsoft.Json;

namespace DOcean.API.Models.Requests
{
    public class Volume
    {
        /// <summary>
        /// The size of the Block Storage volume in GiB (1024^3).
        /// </summary>
        [JsonProperty("size_gigabytes")]
        public int SizeGigabytes { get; set; }

        /// <summary>
        /// A human-readable name for the Block Storage volume. Must be lowercase and be composed only of numbers, 
        /// letters and "-", up to a limit of 64 characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// An optional free-form text field to describe a Block Storage volume.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; }

        /// <summary>
        /// The region where the Block Storage volume will be created. When setting a region, the value should be the 
        /// slug identifier for the region. When you query a Block Storage volume, the entire region object will be 
        /// returned. Should not be specified with a snapshot_id.
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }

        /// <summary>
        /// The unique identifier for the volume snapshot from which to create the volume. 
        /// Should not be specified with a region_id.
        /// </summary>
        [JsonProperty("snapshot_id")]
        public string SnapshotId { get; set; }
    }
}
