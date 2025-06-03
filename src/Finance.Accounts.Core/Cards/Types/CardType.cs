namespace Finance.Core.Types
{
    /// <summary>
    /// Enumeration representing different types of payment cards.
    /// https://www.bincodes.com/bin-list/
    /// </summary>
    public enum CardType : int
    {
        Unknown = 0,
        UATP = 1,
        Visa = 4,
        MasterCard = 5,
        AmericanExpress = 34,
        JCB = 35,
        DinersClub = 36,
        ChinaUnionPay = 62,
        Discover = 65,
        Maestro = 67,
        Unsupported = 99 // Used for unsupported cards
    }
}
