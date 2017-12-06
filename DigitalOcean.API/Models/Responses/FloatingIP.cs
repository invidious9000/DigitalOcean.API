namespace DOcean.API.Models.Responses
{
    public class FloatingIp
    {
        /// <summary>
        /// The public IP address of the Floating IP. It also serves as its identifier.
        /// </summary>
        public string Ip { get; set; }

        /// <summary>
        /// The region that the Floating IP is reserved to. When you query a Floating IP, 
        /// the entire region object will be returned.
        /// </summary>
        public Region Region { get; set; }

        /// <summary>
        /// The Droplet that the Floating IP has been assigned to. When you query a Floating IP, 
        /// if it is assigned to a Droplet, the entire Droplet object will be returned. If it is not assigned, 
        /// the value will be null.
        /// </summary>
        public Droplet Droplet { get; set; }
    }
}