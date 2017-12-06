using System;

namespace DigitalOcean.API.Tests {
    public static class Factory {
        public static IDigitalOceanClient GetClient() {
          //  return new DigitalOceanClient(Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY"));
            return new DigitalOceanClient("90ac955b4ae5bae49bfbd57bd3231f5ac9d72dc1e0d26ce7b805cdc177956bd6");
        }
    }
}