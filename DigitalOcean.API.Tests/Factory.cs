﻿using System;

namespace DOcean.API.Tests
{
    public static class Factory
    {
        public static IDigitalOceanClient GetClient()
        {
            return new DigitalOceanClient(Environment.GetEnvironmentVariable("DIGITALOCEAN_API_KEY"));
        }
    }
}