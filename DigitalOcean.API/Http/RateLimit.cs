using System;
using System.Collections.Generic;
using System.Linq;
using RestSharp;

namespace DOcean.API.Http
{
    public class RateLimit : IRateLimit
    {
        public RateLimit(IList<Parameter> headers)
        {
            Limit = GetHeaderValue(headers, "RateLimit-Limit");
            Remaining = GetHeaderValue(headers, "RateLimit-Remaining");
            Reset = GetHeaderValue(headers, "RateLimit-Reset");
        }

        #region IRateLimit Members

        /// <inheritdoc />
        /// <summary>
        /// The number of requests that can be made per hour.
        /// </summary>
        public int Limit { get; }

        /// <inheritdoc />
        /// <summary>
        /// The number of requests that remain before you hit your request limit.
        /// </summary>
        public int Remaining { get; }

        /// <inheritdoc />
        /// <summary>
        /// This represents the time when the oldest request will expire. The value is given in Unix epoch time.
        /// </summary>
        public int Reset { get; }

        #endregion

        private static int GetHeaderValue(IEnumerable<Parameter> headers, string name)
        {
            var header = headers.FirstOrDefault(x => x.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase));
            return header != null && int.TryParse(header.Value.ToString(), out var value) ? value : 0;
        }
    }
}