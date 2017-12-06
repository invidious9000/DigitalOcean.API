using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DOcean.API.Tests.Clients
{
    public class FloatingIpsClientTest
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