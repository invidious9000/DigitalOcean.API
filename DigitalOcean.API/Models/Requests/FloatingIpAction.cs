using Newtonsoft.Json;

namespace DOcean.API.Models.Requests
{
    public class FloatingIpAction
    {
        /// <summary>
        /// This is the type of action that the object represents. For example, this could be "assign_ip" to 
        /// represent the state of a Floating IP assign action.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }

        /// <summary>
        /// The ID of Droplet that the Floating IP will be assigned to. (Assignment)
        /// </summary>
        [JsonProperty("droplet_id")]
        public int DropletId { get; set; }
    }
}