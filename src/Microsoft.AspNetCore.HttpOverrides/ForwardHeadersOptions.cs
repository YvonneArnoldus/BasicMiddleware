using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;

namespace Microsoft.AspNetCore.HttpOverrides
{
    public class ForwardHeadersOptions
    {
        public IEnumerable<Forwarder> Forwarders { get; set; }
    }
}
