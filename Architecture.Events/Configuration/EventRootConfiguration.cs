using System.Collections.Generic;

namespace Architecture.Events.Configuration
{
    public class EventRootConfiguration
    {
        public IEnumerable<EventConfiguration> EventConfigurations { get; set; }
    }
}