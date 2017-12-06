using DOcean.API.Clients.RestSharp;
using DOcean.API.Helpers;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DOcean.API.Tests
{
    public class DropletUtilsTests
    {

        [Fact]
        public async void CorrectRequestForGetAll()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            var body = new Models.Requests.Droplet();
            var droplet = await client.Create(body);

            await DropletUtils.AwaitStatus(client, droplet.Id, "active");

            //            client.GetAll();
            //
            //            factory.Received().GetPaginated<Size>("sizes", null, "sizes");
        }
    }
}
