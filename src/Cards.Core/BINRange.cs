using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core
{
    public class BINRange
    {
        public string Id { get; set; } = string.Empty;
        public Range[] Ranges { get; set; } = new Range[] { };

        public BINRange() 
        { 
        
        }

        public BINRange(string id, Range[] ranges)
        {
            Id = id;
            Ranges = ranges;
        }
    }
}
