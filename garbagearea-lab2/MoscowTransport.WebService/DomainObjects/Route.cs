using System;
using System.Collections.Generic;
using System.Text;

namespace GarbageArea.DomainObjects
{
    public class GarbageArea : DomainObject
    {
        public string AreaNumber { get; set; }

        public string AreaType { get; set; }

        public int AreaSize { get; set; }

    }
}
