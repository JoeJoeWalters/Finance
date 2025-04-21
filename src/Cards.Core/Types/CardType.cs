using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards.Core.Types
{
    /// <summary>
    /// Enumeration representing different types of payment cards.
    /// </summary>
    public enum CardType
    {
        Unknown,
        Visa,
        MasterCard,
        AmericanExpress,
        Discover,
        DinersClub,
        JCB
    }
}
