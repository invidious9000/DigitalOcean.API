﻿using System.Collections.Generic;
using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DOcean.API.Tests.Clients
{
    public class ImageActionsClientTest
    {
        [Fact]
        public void CorrectRequestForGetAction()
        {
            var factory = Substitute.For<IConnection>();
            var client = new ImageActionsClient(factory);

            client.GetAction(9001, 1009);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001 &&
                                                             (int) list[1].Value == 1009);
            factory.Received().ExecuteRequest<Action>("images/{imageId}/actions/{actionId}",
                parameters, null, "action");
        }

        [Fact]
        public void CorrectRequestForTransfer()
        {
            var factory = Substitute.For<IConnection>();
            var client = new ImageActionsClient(factory);

            client.Transfer(9001, "sfo1");

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            var body = Arg.Is<Models.Requests.Action>(
                action => action.Type == "transfer" && action.RegionSlug == "sfo1");
            factory.Received().ExecuteRequest<Action>("images/{imageId}/actions",
                parameters, body, "action", Method.POST);
        }
    }
}