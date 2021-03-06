﻿using Newtonsoft.Json;

namespace DOcean.API.Models.Requests
{
    public class FloatingIp
    {
        /// <summary>
        /// The ID of Droplet that the Floating IP will be assigned to. (Assignment)
        /// </summary>
        [JsonProperty("droplet_id")]
        public int DropletId { get; set; }

        /// <summary>
        /// The slug identifier for the region the Floating IP will be reserved to. (Reservation)
        /// </summary>
        [JsonProperty("region")]
        public string Region { get; set; }
    }
}