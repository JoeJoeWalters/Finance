using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core.Types
{
    public class CardFeatures
    {
        public string[] CardMIIRanges { get; set; }

        public Range CardSizeRanges { get; set; }

        public CardFeatures(string[] cardMIIRanges, Range cardSizeRanges)
        {
            CardMIIRanges = cardMIIRanges;
            CardSizeRanges = cardSizeRanges;
        }
    }
}
