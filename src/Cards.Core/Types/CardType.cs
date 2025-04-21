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
    public enum CardType : int
    {
        Unknown = 0,
        Visa = 4,
        MasterCard = 5,
        AmericanExpress = 34,
        JCB = 35,
        DinersClub = 36,
        ChinaUnionPay = 62,
        Discover = 65,
        Maestro = 67,
    }
}
