using System.Collections.Generic;

namespace WebAppConfiguration.Models
{
    public class HomeViewModel
    {
        public PortalOptions PortalOptions { get; set; }

        public IEnumerable<AdapterOptions> Adapters { get; set; }
    }
}