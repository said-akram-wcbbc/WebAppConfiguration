using System.Collections.Generic;

namespace WebAppConfiguration.Models
{
    public class PortalOptions
    {
        public const string Portal = "Portal";

        public string DisplayName { get; set; }

        public IEnumerable<string> Adapters { get; set; }
    }
}