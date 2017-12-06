using System.Collections.Generic;
using DOcean.API.Clients;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DOcean.API.Tests.Clients {
    public class ActionsClientTest {
        [Fact]
        public void CorrectRequestForGet() {
            var factory = Substitute.For<IConnection>();
            var actionClient = new ActionsClient(factory);

            actionClient.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int)list[0].Value == 9001);
            factory.Received().ExecuteRequest<Action>("actions/{id}", parameters, null, "action");
        }

        [Fact]
        public void CorrectRequestForGetAll() {
            var factory = Substitute.For<IConnection>();
            var actionClient = new ActionsClient(factory);

            actionClient.GetAll();
            factory.Received().GetPaginated<Action>("actions", null, "actions");
        }
    }
}