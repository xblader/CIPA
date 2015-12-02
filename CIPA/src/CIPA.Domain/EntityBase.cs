using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CIPA.Domain
{
    public class EntityBase
    {
        public string Key { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
