using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOcean.API.Clients;
using DOcean.API.Http;
using DOcean.API.Models.Requests;
using NSubstitute;
using Xunit;
using FloatingIp = DOcean.API.Models.Responses.FloatingIp;

namespace DOcean.API.Tests.Clients
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
