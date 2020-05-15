using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageArea.DomainObjects
{
    public class Route : DomainObject
    {
        public string Number { get; set; }

        public string Name { get; set; }

        public TransportOrganization Organization { get; set; }

        public TransportType Type { get; set; }
    }
}
