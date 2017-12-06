using System.Collections.Generic;
using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using DOcean.API.Models.Requests;
using NSubstitute;
using RestSharp;
using Xunit;

namespace DOcean.API.Tests.Clients
{
    public class KeysClientTest
    {
        [Fact]
        public void CorrectRequestForCreate()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Key {Name = "example"};
            client.Create(body);

            factory.Received().ExecuteRequest<Models.Responses.Key>("account/keys", null, body, "ssh_key", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDeleteFingerprint()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Delete("fingerprint");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "fingerprint");
            factory.Received().ExecuteRaw("account/keys/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForDeleteId()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Delete(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().ExecuteRaw("account/keys/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForGetAll()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Models.Responses.Key>("account/keys", null, "ssh_keys");
        }

        [Fact]
        public void CorrectRequestForGetFingerprint()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Get("fingerprint");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "fingerprint");
            factory.Received().ExecuteRequest<Models.Responses.Key>("account/keys/{id}", parameters, null, "ssh_key");
        }

        [Fact]
        public void CorrectRequestForGetId()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            client.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().ExecuteRequest<Models.Responses.Key>("account/keys/{id}", parameters, null, "ssh_key");
        }

        [Fact]
        public void CorrectRequestForUpdateFingerprint()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Key {Name = "example"};
            client.Update("fingerprint", body);

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "fingerprint");
            factory.Received()
                .ExecuteRequest<Models.Responses.Key>("account/keys/{id}", parameters, body, "ssh_key", Method.PUT);
        }

        [Fact]
        public void CorrectRequestForUpdateId()
        {
            var factory = Substitute.For<IConnection>();
            var client = new KeysClient(factory);

            var body = new Key {Name = "example"};
            client.Update(9001, body);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received()
                .ExecuteRequest<Models.Responses.Key>("account/keys/{id}", parameters, body, "ssh_key", Method.PUT);
        }
    }
}