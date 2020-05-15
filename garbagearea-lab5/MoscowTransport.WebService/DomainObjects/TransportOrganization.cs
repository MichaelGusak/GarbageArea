using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageArea.DomainObjects
{
    public class TransportOrganization : DomainObject
    {
        public string Name { get; set; }

        public string WebSite { get; set; }

        public string TimeZone { get; set; }
    }
}
