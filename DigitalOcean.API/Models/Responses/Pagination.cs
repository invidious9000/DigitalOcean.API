using System.Diagnostics.CodeAnalysis;

namespace DOcean.API.Models.Responses
{
    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Pages
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string Next { get; set; }
    }

    [SuppressMessage("ReSharper", "ClassNeverInstantiated.Global")]
    public class Pagination
    {
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Pages Pages { get; set; }
    }
}