using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DOcean.API.Tests.Clients
{
    public class RegionsClientTest
    {
        [Fact]
        public void CorrectRequestForGetAll()
        {
            var factory = Substitute.For<IConnection>();
            var client = new RegionsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Region>("regions", null, "regions");
        }
    }
}