namespace Finance.Core.Bank.Types
{
    public class CCCCRecord
    {
        public string Status { get; set; } = string.Empty;
        public DateTime? EffectiveDateofLastChange { get; set; }
        public string DateClosed { get; set; } = string.Empty;
        public string SettlementBank { get; set; } = string.Empty;
        public string DebitAgencySortingCode { get; set; } = string.Empty;
        public string ReturnIndicator { get; set; } = string.Empty;
        public string GBNIIndicator { get; set; } = string.Empty;
    }

}
