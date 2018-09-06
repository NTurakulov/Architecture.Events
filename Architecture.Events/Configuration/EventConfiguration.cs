using System.Collections.Generic;

namespace Architecture.Events.Configuration
{
    public class EventConfiguration
    {
        public EventType Type { get; set; }

        public IEnumerable<ResponseConfiguration> ResponseConfigurations { get; set; }
    }
}
