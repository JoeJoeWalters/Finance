namespace Finance.Core.SortCodes.Types
{
    public class CHAPSRecord
    {
        public string ReturnIndicator { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public DateTime? EffectiveDateOfLastChange { get; set; }
        public DateTime? DateClosed { get; set; }
        public string SettlementMember { get; set; } = string.Empty;
        public string RoutingBICField1 { get; set; } = string.Empty;
        public string RoutingBICField2 { get; set; } = string.Empty;
        public string SwiftData { get; set; } = string.Empty;
        public string Spare1 { get; set; } = string.Empty;
    }
}
