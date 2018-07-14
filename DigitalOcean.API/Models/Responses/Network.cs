using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace DOcean.API.Models.Responses
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public class Interface
    {
        public string IpAddress { get; set; }
        public string Netmask { get; set; }
        public string Gateway { get; set; }
        public string Type { get; set; }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class Network
    {
        public List<Interface> v4 { get; set; }
        public List<Interface> v6 { get; set; }
    }
}