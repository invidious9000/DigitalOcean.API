using System.Collections.Generic;
using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using DOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using Xunit;
using Tag = DOcean.API.Models.Responses.Tag;

namespace DOcean.API.Tests.Clients
{
    public class TagsClientTest
    {
        [Fact]
        public void CorrectRequestForCreate()
        {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.Create("notarealtag");

            factory.Received().ExecuteRequest<Tag>("tags", null,
                Arg.Is<Models.Requests.Tag>(data => data.Name == "notarealtag"), "tag", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDelete()
        {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.Delete("notarealtag");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "notarealtag");
            factory.Received().ExecuteRaw("tags/{name}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForGet()
        {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.Get("notarealtag");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "notarealtag");
            factory.Received().ExecuteRequest<Tag>("tags/{name}", parameters, null, "tag");
        }

        [Fact]
        public void CorrectRequestForGetAll()
        {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Tag>("tags", null, "tags");
        }

        [Fact]
        public void CorrectRequestForTag()
        {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            var resources = new List<KeyValuePair<string, string>>(new[]
            {
                new KeyValuePair<string, string>("9001", "droplet"),
                new KeyValuePair<string, string>("9002", "droplet")
            });

            client.Tag("notarealtag", resources);

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "notarealtag");
            factory.Received().ExecuteRaw("tags/{name}/resources", parameters,
                Arg.Is<TagResource>(data => data.Resources[1].Id == "9002"), Method.POST);
        }

        [Fact]
        public void CorrectRequestForUntag()
        {
            var factory = Substitute.For<IConnection>();
            var client = new TagsClient(factory);

            var resources = new List<KeyValuePair<string, string>>(new[]
            {
                new KeyValuePair<string, string>("9001", "droplet"),
                new KeyValuePair<string, string>("9002", "droplet")
            });

            client.Untag("notarealtag", resources);

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "notarealtag");
            factory.Received().ExecuteRaw("tags/{name}/resources", parameters,
                Arg.Is<TagResource>(data => data.Resources[1].Id == "9002"), Method.DELETE);
        }
    }
}