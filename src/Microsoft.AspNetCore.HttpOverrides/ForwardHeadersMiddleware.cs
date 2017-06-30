using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Microsoft.AspNetCore.HttpOverrides
{
    public class ForwardHeadersMiddleware
    {
        private readonly ForwardHeadersOptions _options;
        private readonly RequestDelegate _next;
        private readonly ILoggerFactory _loggerFactory;

        public ForwardHeadersMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IOptions<ForwardHeadersOptions> options)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }
            if (loggerFactory == null)
            {
                throw new ArgumentNullException(nameof(loggerFactory));
            }
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }
            _options = options.Value;
            _loggerFactory = loggerFactory;
            _next = next;
        }

        public Task Invoke(HttpContext context)
        {
            foreach (var forwarder in _options.Forwarders)
                forwarder.Apply(context);

            return _next(context);
        }
    }
}
