using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Builder
{
    public abstract class Forwarder
    {
        public abstract void Apply(HttpContext context);
    }
}
