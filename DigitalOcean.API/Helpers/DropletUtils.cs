using System;
using System.Threading;
using System.Threading.Tasks;
using DOcean.API.Clients;
using DOcean.API.Models.Responses;

namespace DOcean.API.Helpers
{
    public static class DropletUtils
    {
        public static async Task<Droplet> AwaitStatus(IDropletsClient client, int dropletId, string status, TimeSpan? timeout = null, CancellationToken token = default(CancellationToken))
        {
            if (timeout == null)
            {
                timeout = TimeSpan.FromMinutes(2);
            }

            Droplet droplet;
            var startTime = DateTime.Now;

            while ((droplet = await client.Get(dropletId)).Status != status && !token.IsCancellationRequested)
            {
                if (DateTime.Now - startTime < timeout)
                    throw new TimeoutException();

                await Task.Delay(TimeSpan.FromSeconds(1), token);
            }
            return droplet;
        }
    }
}
