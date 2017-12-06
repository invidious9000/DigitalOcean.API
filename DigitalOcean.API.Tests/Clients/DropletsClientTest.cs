using System.Collections.Generic;
using DOcean.API.Clients.RestSharp;
using DOcean.API.Http;
using DOcean.API.Models.Responses;
using NSubstitute;
using RestSharp;
using Xunit;
using Action = DOcean.API.Models.Responses.Action;
using Droplet = DOcean.API.Models.Requests.Droplet;
using Image = DOcean.API.Models.Responses.Image;

namespace DOcean.API.Tests.Clients
{
    public class DropletsClientTest
    {
        [Fact]
        public void CorrectRequestForCreate()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            var body = new Droplet();
            client.Create(body);

            factory.Received().ExecuteRequest<Models.Responses.Droplet>("droplets", null, body, "droplet", Method.POST);
        }

        [Fact]
        public void CorrectRequestForDelete()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.Delete(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().ExecuteRaw("droplets/{id}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForDeleteByTag()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.DeleteByTag("notarealtag");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "notarealtag");
            factory.Received().ExecuteRaw("droplets?tag_name={name}", parameters, null, Method.DELETE);
        }

        [Fact]
        public void CorrectRequestForGet()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.Get(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().ExecuteRequest<Models.Responses.Droplet>("droplets/{id}", parameters, null, "droplet");
        }

        [Fact]
        public void CorrectRequestForGetActions()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetActions(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().GetPaginated<Action>("droplets/{id}/actions", parameters, "actions");
        }

        [Fact]
        public void CorrectRequestForGetAll()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetAll();

            factory.Received().GetPaginated<Models.Responses.Droplet>("droplets", null, "droplets");
        }

        [Fact]
        public void CorrectRequestForGetAllByTag()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetAllByTag("notarealtag");

            var parameters = Arg.Is<List<Parameter>>(list => (string) list[0].Value == "notarealtag");
            factory.Received()
                .GetPaginated<Models.Responses.Droplet>("droplets?tag_name={name}", parameters, "droplets");
        }

        [Fact]
        public void CorrectRequestForGetBackups()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetBackups(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().GetPaginated<Image>("droplets/{id}/backups", parameters, "backups");
        }

        [Fact]
        public void CorrectRequestForGetKernels()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetKernels(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().GetPaginated<Kernel>("droplets/{id}/kernels", parameters, "kernels");
        }

        [Fact]
        public void CorrectRequestForGetSnapshots()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetSnapshots(9001);

            var parameters = Arg.Is<List<Parameter>>(list => (int) list[0].Value == 9001);
            factory.Received().GetPaginated<Image>("droplets/{id}/snapshots", parameters, "snapshots");
        }

        [Fact]
        public void CorrectRequestForGetUpgrades()
        {
            var factory = Substitute.For<IConnection>();
            var client = new DropletsClient(factory);

            client.GetUpgrades();

            factory.Received().GetPaginated<DropletUpgrade>("droplet_upgrades", null);
        }
    }
}