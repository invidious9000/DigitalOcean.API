using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DigitalOcean.API.Clients;
using DigitalOcean.API.Http;
using DigitalOcean.API.Models.Requests;
using NSubstitute;
using Xunit;
using FloatingIp = DigitalOcean.API.Models.Responses.FloatingIp;

namespace DigitalOcean.API.Tests.Clients
{
  public  class FloatingIpsClientTest
    {
        [Fact]
        public void CorrectRequestForGetAll()
        {
            var factory = Substitute.For<IConnection>();
            var client = new FloatingIpsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<FloatingIp>("floating_ips", null, "floating_ips");
        }
    }
}
