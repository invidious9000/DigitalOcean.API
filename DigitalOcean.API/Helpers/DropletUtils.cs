using System;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Clients;
using DOcean.API.Models.Responses;

namespace DOcean.API.Helpers
{
    public static class DropletUtils
    {
        public static async Task<Droplet> AwaitStatus(IDropletsClient client, int dropletId, string status,
            TimeSpan? timeout = null, CancellationToken token = default)
        {
            if (timeout == null)
            {
                timeout = TimeSpan.FromMinutes(2);
            }

            Droplet droplet;
            var startTime = DateTime.Now;

            while (!string.Equals((droplet = await client.Get(dropletId, token)).Status, status,
                       StringComparison.InvariantCultureIgnoreCase) && !token.IsCancellationRequested)
            {
                if (DateTime.Now - startTime > timeout)
                    throw new TimeoutException();

                await Task.Delay(TimeSpan.FromSeconds(1), token);
            }

            token.ThrowIfCancellationRequested();

            return droplet;
        }
    }
}