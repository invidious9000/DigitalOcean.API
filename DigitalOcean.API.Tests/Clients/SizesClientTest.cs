using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DOcean.API.Clients;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using Xunit;

namespace DOcean.API.Tests.Clients {
    public class SizesClientTest {
        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var client = new SizesClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Size>("sizes", null, "sizes");
        }
    }
}
